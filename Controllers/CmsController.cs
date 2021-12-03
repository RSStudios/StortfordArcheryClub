using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Models;
using StortfordArchers.Models;
using System.Linq;
using System.Data;
using ClosedXML.Excel;

namespace StortfordArchers.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public CmsController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
        }

        /// <summary>
        /// Gets the blog archive with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="year">The optional year</param>
        /// <param name="month">The optional month</param>
        /// <param name="page">The optional page</param>
        /// <param name="category">The optional category</param>
        /// <param name="tag">The optional tag</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("archive")]
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null,
            Guid? category = null, Guid? tag = null, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardArchive>(id, HttpContext.User, draft);
                model.Archive = await _api.Archives.GetByIdAsync<PostInfo>(id, page, category, tag, year, month);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("post")]
        public async Task<IActionResult> Post(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(id, HttpContext.User, draft);

                if (model.IsCommentsOpen)
                {
                    model.Comments = await _api.Posts.GetAllCommentsAsync(model.Id, true);
                }
                return View(model);
            }
            catch
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Saves the given comment and then redirects to the post.
        /// </summary>
        /// <param name="id">The unique post id</param>
        /// <param name="commentModel">The comment model</param>
        [HttpPost]
        [Route("post/comment")]
        public async Task<IActionResult> SavePostComment(SaveCommentModel commentModel)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(commentModel.Id, HttpContext.User);

                // Create the comment
                var comment = new PostComment
                {
                    IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserAgent = Request.Headers.ContainsKey("User-Agent") ? Request.Headers["User-Agent"].ToString() : "",
                    Author = commentModel.CommentAuthor,
                    Email = commentModel.CommentEmail,
                    Url = commentModel.CommentUrl,
                    Body = commentModel.CommentBody
                };
                await _api.Posts.SaveCommentAndVerifyAsync(commentModel.Id, comment);

                return Redirect(model.Permalink + "#comments");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Route("CommitteeDetails")]
        public async Task<IActionResult> CommitteeDetails(Guid id)
        {
            var committeeDetails = await _api.Pages.GetByIdAsync<CommitteeDetailsPage>(id);

            var model = new CommitteeDetailsViewModel
            {
                CommitteeDetailsPage = committeeDetails,
                CommitteeDetails = (await _api.Sites.GetSitemapAsync())
                .SelectMany(item => item.Items)
                .Select(item =>
                {
                    var page = _api.Pages.GetByIdAsync<CommitteeDetailsPage>
                    (item.Id).Result;

                    var ci = new CommitteeDetailsItem
                    {
                        Role = page.CommitteeDetails[0].Role,
                        MemberName = page.CommitteeDetails[0].MemberName,
                        Email = page.CommitteeDetails[0].Email,
                        PageUrl = page.Permalink

                    };
                    return ci;
                })
            };
            return View(model);


        }

        [Route ("/Contact")]
        public async Task<IActionResult> Contact(Guid id)
        {
            var model = await _api.Pages.GetByIdAsync<ContactPage>(id);
            
            return View("~/Views/Cms/ContactPage.cshtml", model);
        }

        [HttpPost]
        [Route("/Contact")]
        public IActionResult Contact(ContactPage model)
        {
            var data = model;

            //todo
            data.Response = "Your request has been sent";
            //try
            //{
            //    var model = await _loader.GetPageAsync<ContactPage>(id, HttpContext.User);

            //    // Create the comment
            //    var comment = new PostComment
            //    {
            //        IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            //        UserAgent = Request.Headers.ContainsKey("User-Agent") ? Request.Headers["User-Agent"].ToString() : "",
            //        Author = commentModel.CommentAuthor,
            //        Email = commentModel.CommentEmail,
            //        Url = commentModel.CommentUrl,
            //        Body = commentModel.CommentBody
            //    };
            //    await _api.Posts.SaveCommentAndVerifyAsync(commentModel.Id, comment);

            //    return Redirect(model.Permalink + "#comments");
            //}
            //catch (UnauthorizedAccessException)
            //{
            //    return Unauthorized();
            //}

            return View("~/Views/Cms/ContactPage.cshtml", data);
        }
          
        [Route("/TabularPage")]
        public async Task<IActionResult> TabularPage(Guid id)
        {
            var model = await _api.Pages.GetByIdAsync<PageWithTable>(id);

            string filePath = @"D:\SAC\LongbowLadies.xlsx";

            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
              //  DataTable dt = new DataTable();
                model.TableData = "<table style=\"width:100%\" class=\"tabularContainer\">";

                //Loop through the Worksheet rows.
                bool firstRow = true;
                int cellcount;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add column headings to  the Table.
                    if (firstRow)
                    {
                        cellcount = row.Cells().Count();
                        model.TableData += "<thead><tr>";
                        foreach (IXLCell cell in row.Cells())
                        {
                                model.TableData += "<th>" + cell.Value + "</th>";
                         
                        }
                        model.TableData += "</tr></thead><tbody>";
                        firstRow = false;
                    }
                    else
                    {
                     
                        model.TableData += "<tr>";
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            DateTime result;
                            if (DateTime.TryParse(cell.Value.ToString(), out result))
                            {
                                model.TableData += "<td>" + result.ToString("dd/MM/yyyy") + "</td>";
                            }
                            else
                            {
                                model.TableData += "<td>" + cell.Value.ToString() + "</td>";
                            }
                            i++;
                        }
                        model.TableData += "</tr>";
                    }

                  
                }
                model.TableData += "</tbody></table>";
            }
        

            return View("~/Views/Cms/PageWithTable.cshtml", model);
        }
    }
}

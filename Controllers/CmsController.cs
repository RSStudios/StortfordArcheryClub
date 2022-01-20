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
using StortfordArchers.Blocks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using StortfordArchers.Models.ViewModels;

namespace StortfordArchers.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IOptions<MailSettingsOptions> _emailOptions;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public CmsController(IApi api, IModelLoader loader, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IOptions<MailSettingsOptions> emailOptions)
        {
            _api = api;
            _loader = loader;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _emailOptions = emailOptions;   
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


        [Route("/Contact")]
        public async Task<IActionResult> Contact(Guid id)
        {
            var model = await _api.Pages.GetByIdAsync<ContactPage>(id);

            return View("~/Views/Cms/ContactPage.cshtml", model);
        }

        [HttpPost]
        [Route("/Contact")]
        [Produces("application/json")]
        public IActionResult Contact([FromBody]ContactPage model)
        {
            var data = model;

            //todo

            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(model.Name))
            {
                errorMessage.Append("Please enter your name <br/>");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                errorMessage.Append("Please enter an email address<br />");
            }

            if (string.IsNullOrEmpty(model.Message))
            {
                errorMessage.Append("Please enter a message");
            }

            var success = false;
            if (errorMessage.Length == 0)
            {
                success = true;
                string msg = $"{model.Name} has sent the following message.<br /><br /> Their email address is: {model.Email}.<br /><br />Their phone number is: {model.Phone}.<br /><br />  The message reads:<br /> " + model.Message;
                Helper helper = new Helper(_emailOptions.Value);
               

                var result =helper.SendEmail("Get in Touch", msg, string.Empty);

                if (!string.IsNullOrEmpty(result))
                    success = false;

                return Json(new { success, errorMsg = result });
            }

            var errorMsg = errorMessage.ToString();
            return Json(new { success, errorMsg });

        }

        [Route("/TabularPage")]
        public async Task<IActionResult> TabularPage(Guid id)
        {
            var model = await _api.Pages.GetByIdAsync<PageWithTable>(id);

            model.TableData = "";
            model.Message = "";
            List<PageWithTableViewModel> pages = new ();


            foreach (var item in model.Blocks)
            {
                PageWithTableViewModel page = new PageWithTableViewModel();
                if (item.Type == "Piranha.Extend.Blocks.HtmlBlock")
                {
                    page.PageWithTableTypes = Enumerations.PageWithTableTypes.HtmlBlock;
                    page.Block = item;
                }
                    if (item.Type == "StortfordArchers.Blocks.ExcelBlock")
                {
                    Guid guid = item.Id;
                    page.PageWithTableTypes = Enumerations.PageWithTableTypes.ExcelBlock;

                    var uploadItem = (ExcelBlock)item;

                    if (uploadItem.Upload.Media != null)
                    {
                        var url = uploadItem.Upload.Media.PublicUrl.Substring(1).Replace(@"/", @"\");

                        //check file is excel type
                        string ext = GetFileExtension(url);
                        if (ext == ".xlsx" || ext == ".xls")
                        {
                            string webRootPath;
                            if (_webHostEnvironment.EnvironmentName == "Development")
                            {
                                webRootPath = _webHostEnvironment.WebRootPath;
                            }
                            else
                            {
                                webRootPath = _configuration.GetConnectionString("uploadLocation");
                            }


                            // string contentRootPath = _webHostEnvironment.ContentRootPath;

                            string path = "";
                            path = webRootPath + url;

                            try
                            {
                                using (XLWorkbook workBook = new XLWorkbook(path))
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
                                    page.Html = model.TableData;
                                }
                            }
                            catch (Exception ex)
                            {
                                page.Html += ex.Message;
                                page.PageWithTableTypes = Enumerations.PageWithTableTypes.Message;
                            }
                        }
                       
                    }
                    else
                    {
                        page.Html += "Currently nothing to display for this item";
                        page.PageWithTableTypes = Enumerations.PageWithTableTypes.Message;
                    }
                }
                pages.Add(page);
            }


            ViewBag.PageWithTableViewModel = pages;

            return View("~/Views/Cms/PageWithTable.cshtml", model);
        }

        private string GetFileExtension(string fileName)
        {
            string ext = string.Empty;
            int fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (fileExtPos >= 0)
                ext = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);

            return ext;
        }
    }
}

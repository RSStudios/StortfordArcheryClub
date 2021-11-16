using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha;
using Piranha.Models;
using Microsoft.EntityFrameworkCore;
using StortfordArchers.Models;

namespace StortfordArchers.Controllers
{
    public class ImportController : Controller
    {
        private readonly IApi _api;
        private readonly StortfordArchersDbContext _db;

        public IActionResult Index()
        {
            return View();
        }

        public ImportController(IApi api, StortfordArchersDbContext injectedContext)
        {
            _api = api;
            _db = injectedContext;
        }

        [Route("/import")]
        public async Task<IActionResult> Import()
        {
            int importCount = 0;
            int existsCount = 0;

            var site = await _api.Sites.GetDefaultAsync();

            var catalog = await _api.Pages.GetBySlugAsync<CommitteeDetailsPage>("quiver");

            foreach (CommitteeDetails m in _db.CommitteeDetails.Include(c => c.MemberName))
            {
                // if the category page alread exists, then skip to the next iteration of the loop
                CommitteeDetailsPage cm = await _api.Pages.GetBySlugAsync<CommitteeDetailsPage>($"catalog/{m.MemberName}");


            }

            return null;
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StortfordArchers.Blocks;
using StortfordArchers.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StortfordArchers.Models.ViewModels
{
    public class CalendarViewComponent : ViewComponent
    {
        public CalendarBlock Block { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public CalendarViewComponent(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public string MonthName { get; set; }
        public List<CalendarDetails> Calendar { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(CalendarBlock block, Guid pageId )
        {
            //List<CalendarDetails> calendar = new();

            //if (block.Upload.Media != null)
            //{
            //    string webRootPath;
            //    if (_webHostEnvironment.EnvironmentName == "Development")
            //    {
            //        webRootPath = _webHostEnvironment.WebRootPath;
            //    }
            //    else
            //    {
            //        webRootPath = _configuration.GetConnectionString("uploadLocation");
            //    }

            //    ExcelCalendarReader reader = new();
            //    calendar = await reader.GetExcelCalendarResults(block, webRootPath);
            //}


            return View(new CalendarIdViewModel() { CalendarBlockId = block.Id, PageId = pageId});
        }
    }
}

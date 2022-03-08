using Microsoft.AspNetCore.Mvc;
using StortfordArchers.Blocks;
using System;
using System.Threading.Tasks;

namespace StortfordArchers.Models.ViewModels
{
    public class CalendarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CalendarBlock block, Guid pageId )
        {
            return View(new CalendarIdViewModel() { CalendarBlockId = block.Id, PageId = pageId});
        }
    }
}

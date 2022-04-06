using Microsoft.AspNetCore.Mvc;
using StortfordArchers.Blocks;
using System;
using System.Threading.Tasks;

namespace StortfordArchers.Models.ViewModels
{
    public class UpcomingEventsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CalendarBlock block, Guid pageId)
        {
            if (block == null || pageId == Guid.Empty)
                return View(new CalendarIdViewModel());

            return View(new CalendarIdViewModel() { CalendarBlockId = block.Id, PageId = pageId });
        }
    }
}

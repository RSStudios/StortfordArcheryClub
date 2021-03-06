using Microsoft.AspNetCore.Mvc;
using StortfordArchers.Blocks;
using System;
using System.Threading.Tasks;

namespace StortfordArchers.Models.ViewModels
{
    public class UpcomingEventsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UpcomingEventsBlock block, Guid pageId)
        {
            if (block == null || pageId == Guid.Empty)
                return View(new UpcomingEventsIdViewModel());

            return View(new UpcomingEventsIdViewModel() { UpcomingEventsBlockId = block.Id, PageId = pageId });
        }
    }
}

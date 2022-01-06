﻿using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Tabular", UseBlocks = false)]
    [BlockItemType(typeof(StortfordArchers.Blocks.ExcelBlock))]
    [BlockItemType( typeof(Piranha.Extend.Blocks.HtmlBlock))]
    [ContentTypeRoute(Title = "Default", Route = "/TabularPage")]

    public class PageWithTable : Page<PageWithTable>
    {

      
        public string TableData { get; set; }

        public string Message { get; set;}
    }
}

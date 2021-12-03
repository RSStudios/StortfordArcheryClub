using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;

namespace StortfordArchers.Blocks
{
   
    [BlockType(Name = "Excel file upload", Category = "Media", Icon = "fas fa-address-card", Component = "excel-block")]
    public class ExcelBlock : Block
    {
      //  public ImageField ImgBody { get; set; }

        [Field(Placeholder ="Select an Excel format file to  upload")]
       
        public DocumentField Upload { get; set; }


        public override string GetTitle()
        {
            if (Upload != null && Upload.Media != null)
            {
                return Upload.Media.Filename;
            }
            return "No file selected";
        }
    }
}


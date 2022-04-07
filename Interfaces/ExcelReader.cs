using Piranha.Extend.Fields;
using StortfordArchers.Blocks;
using StortfordArchers.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StortfordArchers.Interfaces
{
    public abstract class ExcelReader
    {
        public abstract string GetExcelResults(ExcelBlock excelBlock, string webRootPath);

        public abstract Task<List<CalendarDetails>> GetExcelCalendarResults(DocumentField upload, string webRootPath);

        private string GetFileExtension(string fileName)
        {
            string ext = string.Empty;
            int fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (fileExtPos >= 0)
                ext = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);

            return ext;
        }

        public string GetExcelPath(DocumentField block, string webRootPath)
        {
            var path = "";

            if (block.Media != null)
            {
                var url = block.Media.PublicUrl.Substring(1).Replace(@"/", @"\");

                //check file is excel type
                string ext = GetFileExtension(url);
                if (ext == ".xlsx" || ext == ".xls")
                    path = webRootPath + url;
            }

            return path;
        }
    }
}

using StortfordArchers.Blocks;
using System;

namespace StortfordArchers.Interfaces
{
    public abstract class ExcelReader
    {
        public abstract string GetExcelResults(ExcelBlock excelBlock, string webRootPath);

        private string GetFileExtension(string fileName)
        {
            string ext = string.Empty;
            int fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (fileExtPos >= 0)
                ext = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);

            return ext;
        }

        protected string GetExcelPath(ExcelBlock block, string webRootPath)
        {
            var uploadItem = block;
            var path = "";

            if (uploadItem.Upload.Media != null)
            {
                var url = uploadItem.Upload.Media.PublicUrl.Substring(1).Replace(@"/", @"\");

                //check file is excel type
                string ext = GetFileExtension(url);
                if (ext == ".xlsx" || ext == ".xls")
                    path = webRootPath + url;
            }

            return path;
        }
    }
}

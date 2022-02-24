using ClosedXML.Excel;
using StortfordArchers.Blocks;
using StortfordArchers.Interfaces;
using System;
using System.Linq;

namespace StortfordArchers.Models
{
    public class ExcelResultReader : ExcelReader
    {
        public override string GetExcelResults(ExcelBlock excelBlock, string webRootPath)
        {
            var path = GetExcelPath(excelBlock, webRootPath);
            var tableData = "";
        
                using (XLWorkbook workBook = new XLWorkbook(path))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);

                    //Create a new DataTable.
                    //  DataTable dt = new DataTable();
                    tableData = "<table style=\"width:100%\" class=\"tabularContainer\">";

                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    int cellcount;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add column headings to  the Table.
                        if (firstRow)
                        {
                            cellcount = row.Cells().Count();
                            tableData += "<thead><tr>";
                            foreach (IXLCell cell in row.Cells())
                            {
                                tableData += "<th>" + cell.Value + "</th>";

                            }
                            tableData += "</tr></thead><tbody>";
                            firstRow = false;
                        }
                        else
                        {

                            tableData += "<tr>";
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                DateTime result;
                                if (DateTime.TryParse(cell.Value.ToString(), out result))
                                {
                                    tableData += "<td>" + result.ToString("dd/MM/yyyy") + "</td>";
                                }
                                else
                                {
                                    tableData += "<td>" + cell.Value.ToString() + "</td>";
                                }
                                i++;
                            }
                            tableData += "</tr>";
                        }


                    }
                    tableData += "</tbody></table>";
                }

            return tableData;
        }  
    }
}

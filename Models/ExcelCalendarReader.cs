using ClosedXML.Excel;
using StortfordArchers.Blocks;
using StortfordArchers.Interfaces;
using StortfordArchers.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StortfordArchers.Models
{
    public class ExcelCalendarReader : ExcelReader
    {
        public override async Task<List<CalendarDetails>> GetExcelCalendarResults(CalendarBlock calendarBlock, string webRootPath)
        {
            var path = GetExcelPath(calendarBlock.Upload, webRootPath);
            List<CalendarDetails> calendar = new();

            using (XLWorkbook workBook = new(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Loop through the Worksheet rows.
                var nonEmptyDataRows = workSheet.RowsUsed();

                CalendarDetails calDetails = null;
                //List<CalendarItem> calItems = new();
                CalendarItem calItem = new();

                foreach (var dataRow in nonEmptyDataRows)
                {
                    calItem = new();
                    //for row number check
                    if (dataRow.RowNumber() > 1)
                    {
                        calItem.Time = (string)dataRow.Cell(2).Value;
                        calItem.Title = (string)dataRow.Cell(3).Value;
                        calItem.Description = (string)dataRow.Cell(4).Value;
                        calItem.Location = (string)dataRow.Cell(5).Value;
                        calItem.MapPostcode = (string)dataRow.Cell(6).Value;

                        DateTime val = DateTime.MinValue;
                        try
                        {
                            val= (DateTime)dataRow.Cell(1).Value;
                        }
                        catch { }
                        if (val != DateTime.MinValue)
                        {
                            // new date details
                            if (!calendar.Select(s => s.DateVal).Contains(val))
                            {
                                calDetails = new CalendarDetails
                                {
                                    DateVal = (DateTime)dataRow.Cell(1).Value,
                                    CalItem = new List<CalendarItem>
                                {
                                    calItem
                                }
                                };

                                calendar.Add(calDetails);
                                calItem = new();
                                calDetails = null;
                            }
                            else
                            {
                                calendar.Find(f => f.DateVal == val).CalItem.Add(calItem);
                            }
                        }
                    }
                }
            }

            return calendar;
        }

        public override string GetExcelResults(ExcelBlock excelBlock, string webRootPath)
        {
            throw new NotImplementedException();
        }
    }
}

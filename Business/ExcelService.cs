using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Business
{
    public class ExcelService : IExcelService
    {
        private readonly HttpClient _httpClient;

        public ExcelService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://localhost:7174");
        }

        public async Task<string> AnalyzeExcelFile(byte[] excelData)
        {
            try
            {
                if (excelData == null || excelData.Length == 0)
                {
                    return "Unable to load or empty Excel file.";
                }

                int rowCount = 0;
                int columnCount = 0;
                int nonEmptyRowCount = 0;
                int nonEmptyColumnCount = 0;

                using (var package = new ExcelPackage(new MemoryStream(excelData)))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        return "No readable sheet found in the Excel file.";
                    }

                    var worksheet = package.Workbook.Worksheets[0];

                    if (worksheet.Dimension == null || worksheet.Dimension.Rows < 2 || worksheet.Dimension.Columns < 1)
                    {
                        return "Invalid size of the Excel sheet. It should have at least 1 column and 2 rows.";
                    }

                    rowCount = worksheet.Dimension.Rows;
                    columnCount = worksheet.Dimension.Columns;

                    for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                    {
                        bool isColumnEmpty = true;

                        for (int row = worksheet.Dimension.Start.Row; row <= worksheet.Dimension.End.Row; row++)
                        {
                            var cellValue = worksheet.Cells[row, col].Text;

                            if (!string.IsNullOrWhiteSpace(cellValue))
                            {
                                isColumnEmpty = false;
                                break;
                            }
                        }

                        if (!isColumnEmpty)
                        {
                            nonEmptyColumnCount++;
                        }
                    }

                    for (int row = worksheet.Dimension.Start.Row; row <= worksheet.Dimension.End.Row; row++)
                    {
                        bool isRowEmpty = true;

                        for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Text;

                            if (!string.IsNullOrWhiteSpace(cellValue))
                            {
                                isRowEmpty = false;
                                break;
                            }
                        }

                        if (!isRowEmpty)
                        {
                            nonEmptyRowCount++;
                        }
                    }
                }

                return $"Total {rowCount} rows and {columnCount} columns found. Non-empty row count: {nonEmptyRowCount}. Non-empty column count: {nonEmptyColumnCount}.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during analysis: {ex.Message}");
                return "An error occurred during the analysis.";
            }
        }
    }
}

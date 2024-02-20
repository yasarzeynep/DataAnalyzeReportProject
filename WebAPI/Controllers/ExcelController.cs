using Business;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

[ApiController]
[Route("api/[controller]")]
public class ExcelController : ControllerBase
{
    private readonly IExcelService _excelService;

    public ExcelController(IExcelService excelService)
    {
        _excelService = excelService ?? throw new ArgumentNullException(nameof(excelService));
    }

    [HttpPost("analyze")]
    public IActionResult AnalyzeExcel([FromBody] byte[] excelData)
    {
        try
        {
            string analysisResult = _excelService.AnalyzeExcelFile(excelData).Result;
            return Ok(new { Result = analysisResult });
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Invalid operation during analysis: {ex.Message}");
            return BadRequest("An error occurred during analysis. Please make sure you upload a valid Excel file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during analysis: {ex.Message}");
            return BadRequest("An error occurred during analysis.");
        }
    }
}

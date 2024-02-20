using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController : ControllerBase
{
    private readonly ILinkService _linkService;

    public LinkController(ILinkService linkService)
    {
        _linkService = linkService ?? throw new ArgumentNullException(nameof(linkService));
    }

    [HttpPost("analyze")]
    public async Task<IActionResult> AnalyzeLink([FromBody] string link)
    {
        try
        {
            if (!LinkValidator.IsLinkValid(link))
            {
                return BadRequest("Invalid link format.");
            }

            string analysisResult = await _linkService.AnalyzeLinkContent(link);
            return Ok(new { Result = analysisResult });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during link analysis: {ex.Message}");
            return BadRequest("An error occurred during link analysis.");
        }
    }
}
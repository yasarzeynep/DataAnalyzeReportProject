using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Business;

public class LinkService : ILinkService
{
    private readonly HttpClient _httpClient;

    public LinkService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://localhost:7174");
    }
    public async Task<string> AnalyzeLinkContent(string link)
    {
        try
        {
            if (!LinkValidator.IsLinkValid(link))
            {
                return "Invalid link format.";
            }

            // Link içeriğini analiz etmek için gerekli işlemleri yapın
            // Bu örnekte sadece basit bir mesaj döndürüyorum
            return $"Link content has been analyzed. Link: {link}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during link analysis: {ex.Message}");
            return "An error occurred during link analysis.";
        }
    }

}

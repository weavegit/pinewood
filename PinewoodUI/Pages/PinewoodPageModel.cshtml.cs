using Microsoft.AspNetCore.Mvc.RazorPages;
using Common.Entities;
using Newtonsoft.Json;
namespace PinewoodUI.Pages
{

    public class PinewoodPageModel : PageModel
    {

        protected string Url_Lcl = "https://localhost:7070";
 



        protected async Task<HttpResponseMessage>? GetServer(string endpoint)
        {
            using var client = new HttpClient();
            var connection = await client.GetAsync(Url_Lcl + endpoint);

            return connection;
        }
    }
}

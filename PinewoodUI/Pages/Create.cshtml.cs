using Microsoft.AspNetCore.Mvc;

using Common.Entities;
using Newtonsoft.Json;
using System.Text;



namespace PinewoodUI.Pages
{
    public class CreateModel : PinewoodPageModel
    {
         [BindProperty]
        public required Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return Page();
            }

            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Customer);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            if (data != null)
            {
                
                var response = await client.PostAsync(Url_Lcl+"/api/Customer/", data);
                string result = response.Content.ReadAsStringAsync().Result;

            }

            return RedirectToPage("Index");
        }
    }
}

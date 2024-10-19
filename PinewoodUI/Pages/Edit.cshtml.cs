using Microsoft.AspNetCore.Mvc;
using Common.Entities;
using Newtonsoft.Json;
using System.Text;

namespace PinewoodUI.Pages
{
    public class EditModel : PinewoodPageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                using var client = new HttpClient();
                var server = GetServer("/api/Customer/"+ id);

                if (server != null)
                {
                    var response = server.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        Customer = JsonConvert.DeserializeObject<Customer>(json);
                    }

                }
            }
            catch (Exception ex)
            {
      
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return Page();
            }

            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            if (data != null) {
                var response = await client.PutAsync(Url_Lcl + "/api/Customer/" + Customer.Id, data);
                string result = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToPage("Index");
        }
    }
}

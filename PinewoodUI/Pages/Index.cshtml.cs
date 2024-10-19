using Common.Entities;
using Newtonsoft.Json;
namespace PinewoodUI.Pages
{

    public class IndexModel : PinewoodPageModel
    {
        public IList<Customer>? Customers { get; set; }

        public async void OnGetAsync()
        {
            try
            {
                using var client = new HttpClient();
                var server = GetServer("/api/Customer");

                if (server != null) {
                    var response = server.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }
 
                }
            }
            catch (Exception ex) { 
              return;
            }
        }

        public async void OnPostAsync()
        {
            try
            {
                using var client = new HttpClient();
                var server = GetServer("/api/Customer");

                if (server != null)
                {
                    var response = server.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using TestTaskAsp.Model;

namespace TestTaskAsp.Service
{
    public class IPService
    {
        public async Task<string> getMyCity()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://ipinfo.io/json")
            };

            var response = await client.GetAsync("");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            IPModel model = JsonConvert.DeserializeObject<IPModel>(responseBody);

            return model.city;
        }
    }
}

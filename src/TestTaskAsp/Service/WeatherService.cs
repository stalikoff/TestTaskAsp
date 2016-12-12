using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskAsp.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestTaskAsp.Service
{
    public class WeatherService
    {
        public async Task<Root> getForecast(string city)
        {
            string urlString = "http://api.apixu.com/v1/forecast.json?key=6f0f033585664a5885985526160712&q=" + city + "&days=10";

            var client = new HttpClient
            {
                BaseAddress = new Uri(urlString)
            };

            var response = await client.GetAsync("");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Root model = JsonConvert.DeserializeObject<Root>(responseBody);

            return model;
        }
    }
}

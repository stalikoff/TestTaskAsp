using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace TestTaskAsp.Model
{
    public class IpObject
    {
        public string ip { get; set; }
        public string hostname { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
    }

    public class Root
    {
        [JsonProperty("forecast")]
        public Forecast forecast;

        [JsonProperty("location")]
        public Location location;
    }

    public class Location
    {
        public string name;
    }

    public class Forecast
    {
        [JsonProperty("forecastday")]
        public ForecastDay[] forecastday;
    }

    public class ForecastDay
    {
        public string date { get; set; }

        [JsonProperty("day")]
        public Day day;
    }

    public class Day
    {
        [JsonProperty("condition")]
        public Condition condition;

        [JsonProperty("avgtemp_c")]
        public string temperature;
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }

    public class WeatherModel
    {
        public async Task<Root> getWeather()
        {
            string myCity = await getMyCity();

            Root forecast = await getForecast(myCity);

            return forecast;
        }

        public async Task<string> getMyCity()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://ipinfo.io/json")
            };

            var response = await client.GetAsync("");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            IpObject model = JsonConvert.DeserializeObject<IpObject>(responseBody);

            return model.city;
        }

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

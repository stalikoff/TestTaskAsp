using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace TestTaskAsp.Model
{
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
}

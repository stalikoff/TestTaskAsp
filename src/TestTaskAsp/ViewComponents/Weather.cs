using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskAsp.Model;

namespace TestTaskAsp
{
    public class Weather : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            WeatherModel weatherModel = new WeatherModel();
            var items = await weatherModel.getWeather();

            return View(items);
        }
    }
}

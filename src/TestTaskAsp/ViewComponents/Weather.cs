using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskAsp.Model;
using TestTaskAsp.Service;

namespace TestTaskAsp
{
    public class Weather : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IPService ipService = new IPService();
            string city = await ipService.getMyCity();

            WeatherService weatherService = new WeatherService();
            Root rootmodel = await weatherService.getForecast(city);

            return View(rootmodel);
        }
    }
}

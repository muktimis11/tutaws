using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutaws;

namespace TutWebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [Route("post")]
        [HttpPost]
        public List<string> PostiteminProductcatalogue1([FromQuery] string Title, [FromQuery] string id)
        {

            var respo = DB.CreateItem(Title, id);
            List<string> str = new List<string>();
            str.Add(respo);
            return str;
    
        }


    

        //    public List<string> PostiteminProductcatalogue1([FromQuery] string Title, [FromQuery] string id)
        //{

        //    var respo = DB.CreateItem(Title, id);
        //    List<string> str = new List<string>();
        //    str.Add(respo);
        //    return str;
        //    //var rng = new Random();
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();
        //}
        //[Route("get")]
        //[HttpGet]
        //public ProductCatalogue1 FetchProductcatalogue1([FromQuery] string id)
        //{

        //   ProductCatalogue1 response =  DB.GetallItems(id);
        //    //List<string> str = new List<string>();
        //    //str.Add(respo);
        //    //return str;
        //    //var rng = new Random();
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //})
        //    return response;
        //}
        [Route("get")]
        [HttpGet]
        public Game Fetchgame()
        {

            Game response = DB.GetallItemsss();
            //List<string> str = new List<string>();
            //str.Add(respo);
            //return str;
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            return response;
        }

    }
}
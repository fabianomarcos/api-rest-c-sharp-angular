using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
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

        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return new Event[] {
              new Event() {
                EventId = 1,
                Theme = "Curso dotnet",
                Locale = "Lagoa Santa",
                Lot = "1 Lote",
                AmountPeoples = 250,
                DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
              },
              new Event() {
                EventId = 2,
                Theme = "Curso Angular",
                Locale = "Lagoa Santa",
                Lot = "2 Lote",
                AmountPeoples = 350,
                DateEvent = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
              }
            };
        }

        public ActionResult<Event> Get(int id) => new Event[] {
              new Event() {
                EventId = 1,
                Theme = "Curso dotnet",
                Locale = "Lagoa Santa",
                Lot = "1 Lote",
                AmountPeoples = 250,
                DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
              },
              new Event() {
                EventId = 2,
                Theme = "Curso Angular",
                Locale = "Lagoa Santa",
                Lot = "2 Lote",
                AmountPeoples = 350,
                DateEvent = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
              }
        }.FirstOrDefault(Event => Event.EventId == id);
    }
}

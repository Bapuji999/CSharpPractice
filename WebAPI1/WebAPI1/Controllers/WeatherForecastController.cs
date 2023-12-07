using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
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
        private readonly IEmploye _employe;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmploye employe)
        {
            _logger = logger;
            _employe = employe;
        }

        [HttpGet]
        [Route("[controller]/Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            _employe.Name = "Abinash";
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                EmpName = _employe.Name,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("[controller]/Method")]
        public IEnumerable<WeatherForecast> Method([FromServices] IEmploye _employe1)
        {
            _employe1.Name = "Abinash";
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                EmpName = _employe1.Name,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

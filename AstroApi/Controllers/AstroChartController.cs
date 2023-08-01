using Microsoft.AspNetCore.Mvc;
using AryanEphemeris;
using AryanEphemeris.Samples;

namespace AstroApi.Controllers
{
    [ApiController]
    public class AstroChartController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public AstroChartController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/astrochart/get")]
        public IEnumerable<AstroChart> Get()
        {
            var ephemerisPath = Path.Combine(@"..\data\", "binary.430");
            AryanKernel.LoadEphemeris(ephemerisPath);
            var eph = AryanKernel.GetEphemeris();


            var chuck = new AstroChart(eph, new DateTime(1940, 3, 10, 15, 0, 0), "Chuck", "Norris");

            // result.PrintChart();

            var result = new List<AstroChart>();
            result.Add(chuck);

            return result;
        }
    }
}

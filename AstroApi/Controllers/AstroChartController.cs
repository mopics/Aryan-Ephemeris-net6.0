using Microsoft.AspNetCore.Mvc;
using AryanEphemeris;
using AryanEphemeris.Samples;

namespace AstroApi.Controllers
{
    public class AstroChartController : Controller
    {
        public IActionResult Index()
        {
            var ephemerisPath = Path.Combine(FilePaths.DataPath, "binary.430");
            AryanKernel.LoadEphemeris(ephemerisPath);
            var eph = AryanKernel.GetEphemeris();


            var ChuckNorris = new AstroChart(eph, new DateTime(1940, 3, 10, 15, 0, 0), "Chuck", "Norris");
            ChuckNorris.PrintChart();

            return View();
        }
    }
}

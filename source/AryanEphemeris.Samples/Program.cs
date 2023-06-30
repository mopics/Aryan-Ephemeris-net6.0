using System;
using System.IO;

namespace AryanEphemeris.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var ephemerisPath = Path.Combine(FilePaths.DataPath, "binary.430");
            AryanKernel.LoadEphemeris(ephemerisPath);
            var eph = AryanKernel.GetEphemeris();


            var ChuckNorris = new AstroChart(eph, new DateTime(1940, 3, 10, 15, 0, 0), "Chuck", "Norris");
            var PeterDijkstra = new AstroChart(eph, new DateTime(1974, 3, 5, 12, 0, 0), "Peter", "Dijkstra");

            ChuckNorris.PrintChart();
            PeterDijkstra.PrintChart();
        }
    }
}
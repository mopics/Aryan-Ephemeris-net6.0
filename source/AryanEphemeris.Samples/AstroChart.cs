using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AryanEphemeris.Samples
{
    public struct PlanetInSign
    {
        public EphemerisComponent planet;
        public string sign;
        public double degreesInSign;
        public double degreesTotal;
    }

    public class AstroChart
    {
        public string firstName, lastName;
        public DateTime date;
        public Ephemeris eph;
        public PlanetInSign sun, moon, mercury, venus, mars, jupiter, saturn, uranus, neptune, pluto;

        public AstroChart(Ephemeris eph, DateTime date, string firstName, string lastName)
        {
            this.eph = eph;
            this.date = date;
            this.firstName = firstName;
            this.lastName = lastName;
            InterpolateEphemeris();
        }

        public static string[] signs = {
           "aries", "taurus", "gemini", "cancer", "leo", "virgo", "libra",  "scorpio", "sagitarius", "capricorn", "aquarius", "pisces"
        };

        public static PlanetInSign getPlanet(Ephemeris eph, DateTime date, EphemerisComponent planet)
        {
            var jdate = Utilities.ConvertToJulian(date);
            var coordinates = eph.Interpolate(jdate, planet, EphemerisComponent.Earth);
            var deltaX = coordinates[0];
            var deltaY = coordinates[1];
            var rad = Math.Atan2(deltaY, deltaX); // In radians
            var deg = rad * (180 / Math.PI);

            if (deg < 0)
            {
                deg = 360 + deg;
            }
            var degreeInSign = deg % 30;
            int signIdx = (int)Math.Floor(deg / 30);
            var sign = AstroChart.signs[signIdx];

            return new PlanetInSign
            {
                planet = planet,
                sign = AstroChart.signs[signIdx],
                degreesInSign = (double) deg % 30,
                degreesTotal = (double) deg
            };
        }

        public void InterpolateEphemeris()
        {
            
            sun = AstroChart.getPlanet(eph, date, EphemerisComponent.Sun);
            moon = AstroChart.getPlanet(eph, date, EphemerisComponent.Moon);
            mercury = AstroChart.getPlanet(eph, date, EphemerisComponent.Mercury);
            venus = AstroChart.getPlanet(eph, date, EphemerisComponent.Venus);
            mars = AstroChart.getPlanet(eph, date, EphemerisComponent.Mars);
            jupiter = AstroChart.getPlanet(eph, date, EphemerisComponent.Jupiter);
            saturn = AstroChart.getPlanet(eph, date, EphemerisComponent.Saturn);
            uranus = AstroChart.getPlanet(eph, date, EphemerisComponent.Uranus);
            neptune = AstroChart.getPlanet(eph, date, EphemerisComponent.Neptune);
            pluto = AstroChart.getPlanet(eph, date, EphemerisComponent.Pluto);

        }

        public void PrintChart()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine($"Chart of {firstName} {lastName}");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Sun : {sun.degreesInSign} in {sun.sign}");
            Console.WriteLine($"Moon : {moon.degreesInSign} in {moon.sign}");
            Console.WriteLine($"Mercury : {mercury.degreesInSign} in {mercury.sign}");
            Console.WriteLine($"Venus : {venus.degreesInSign} in {venus.sign}");
            Console.WriteLine($"Mars : {mars.degreesInSign} in {mars.sign}");
            Console.WriteLine($"Jupiter : {jupiter.degreesInSign} in {jupiter.sign}");
            Console.WriteLine($"Saturn : {saturn.degreesInSign} in {saturn.sign}");
            Console.WriteLine($"Uranus : {uranus.degreesInSign} in {uranus.sign}");
            Console.WriteLine($"Neptune : {neptune.degreesInSign} in {neptune.sign}");
            Console.WriteLine($"Pluto : {pluto.degreesInSign} in {pluto.sign}");
            Console.WriteLine("==========================================\n\n");
        }
    }
}
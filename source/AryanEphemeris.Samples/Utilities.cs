using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AryanEphemeris.Samples
{
    internal class Utilities
    {
        public static void ConvertTextToBinaryEphemeris()
        {
            var textEphemeris = Path.Combine(FilePaths.AdditionalDataPath, "text.430");
            var binaryEphemeris = Path.Combine(FilePaths.DataPath, "binary.430");

            using (var builder = new EphemerisBuilder(textEphemeris, binaryEphemeris))
                builder.Build();
        }

        public static long ConvertToJulian(DateTime Date)
        {
            int Month = Date.Month;
            int Day = Date.Day;
            int Year = Date.Year;

            if (Month < 3)
            {
                Month = Month + 12;
                Year = Year - 1;
            }
            long JulianDay = Day + (153 * Month - 457) / 5 + 365 * Year + (Year / 4) - (Year / 100) + (Year / 400) + 1721119;
            return JulianDay;
        }
    }
}

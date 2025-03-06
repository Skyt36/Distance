using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    public static class DistanceCalculator
    {
        private static Tuple<double, double>? getCoordinates(string P)
        {
            if (!(P?.Contains(',') ?? false))
                return null;
            var stringCoordinates = P.Split(',');
            stringCoordinates[0] = stringCoordinates[0].Trim();
            stringCoordinates[1] = stringCoordinates[1].Trim();
            double phi = 0;
            if (!double.TryParse(stringCoordinates[0], CultureInfo.InvariantCulture, out phi))
                return null;
            double L = 0;
            if (!double.TryParse(stringCoordinates[1], CultureInfo.InvariantCulture, out L))
                return null;
            return new Tuple<double, double>(phi * Math.PI / 180, L * Math.PI / 180);
        }
        public static double? Distance(string P1, string P2)
        {
            var coordinate1 = getCoordinates(P1);
            var coordinate2 = getCoordinates(P2);
            if (coordinate1 == null || coordinate2 == null)
                return null;
            return 6371.290681854754 * Math.Acos(Math.Sin(coordinate1.Item1) * Math.Sin(coordinate2.Item1) + Math.Cos(coordinate1.Item1) * Math.Cos(coordinate2.Item1) * Math.Cos(coordinate2.Item2 - coordinate1.Item2));
        }
    }
}

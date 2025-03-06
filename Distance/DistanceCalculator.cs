using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    public static class DistanceCalculator
    {
        private static Tuple<double, double> getCoordinates(string P)
        {
            var stringCoordinates = P.Split(',');
            stringCoordinates[0] = stringCoordinates[0].Replace('.', ',').Trim();
            stringCoordinates[1] = stringCoordinates[1].Replace('.', ',').Trim();
            double phi = 0;
            double.TryParse(stringCoordinates[0], out phi);
            double L = 0;
            double.TryParse(stringCoordinates[1], out L);
            return new Tuple<double, double>(phi * Math.PI / 180, L * Math.PI / 180);
        }
        public static double Distance(string P1, string P2)
        {
            var coordinate1 = getCoordinates(P1);
            var coordinate2 = getCoordinates(P2);
            return 6371.290681854754 * Math.Acos(Math.Sin(coordinate1.Item1) * Math.Sin(coordinate2.Item1) + Math.Cos(coordinate1.Item1) * Math.Cos(coordinate2.Item1) * Math.Cos(coordinate2.Item2 - coordinate1.Item1));
        }
    }
}

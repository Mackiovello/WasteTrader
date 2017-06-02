using System;
using WasteTrader.Database;

namespace WasteTrader.MathUtils
{
    public static class GeographyMath
    {
        private static double DtrDenominator = Math.PI / 180;
        public static double EarthRadius = 6371000;
        public static double EarthDiameter = EarthRadius * 2;
        public static double DegreesToRadians(double degrees)
        {
            return degrees*DtrDenominator;
        }

        public static double Haversine(double radians)
        {
            return (1 - Math.Cos(radians)) * 0.5;
        }

        /// <summary>
        /// Calculates the distance between two points on earth.
        /// Should be about at worst about 0.5% accurate.
        /// </summary>
        public static double RoughEarthDistance(Location loc1, Location loc2)
        {
            return RoughEarthDistance(loc1.LongitudeRadians, loc1.LatitudeRadians, loc2.LongitudeRadians, loc2.LatitudeRadians);
        }

        /// <summary>
        /// Calculates the distance between two points on earth.
        /// Should be about at worst about 0.5% accurate.
        /// All parameters are in radians.
        /// </summary>
        public static double RoughEarthDistance(double longitudeP1, double latitudeP1, double longitudeP2, double latitudeP2)
        {
            return GreatCircleDistance(longitudeP1, latitudeP1, longitudeP2, latitudeP2, EarthDiameter);
        }

        public static double GreatCircleDistance(double longitudeP1, double latitudeP1, double longitudeP2, double latitudeP2, double diameter)
        {
            double havsLong = Haversine(longitudeP1-longitudeP2);
            double havsLati = Haversine(latitudeP1-latitudeP2);
            double inner = havsLati + (Math.Cos(latitudeP1) * Math.Cos(latitudeP2) * havsLong);
            double outer = Math.Asin(Math.Sqrt(inner));
            return diameter * outer;
        }

    }
}

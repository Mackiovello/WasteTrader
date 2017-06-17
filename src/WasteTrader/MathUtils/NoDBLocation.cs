namespace WasteTrader.MathUtils
{
    public class NoDBLocation : ILocation
    {
        public NoDBLocation(double longitudeDD, double latitudeDD)
        {
            this.LongitudeDD = longitudeDD;
            this.LatitudeDD = latitudeDD;
            this.LongitudeRadians = GeographyMath.DegreesToRadians(LongitudeDD);
            this.LatitudeRadians = GeographyMath.DegreesToRadians(LatitudeDD);
        }

        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public double LongitudeRadians { get; }
        public double LatitudeRadians { get; }
    }
}

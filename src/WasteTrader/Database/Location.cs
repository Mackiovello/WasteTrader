using Starcounter;
using WasteTrader.MathUtils;

namespace WasteTrader.Database
{
    [Database]
    public class Location : ILocation
    {

        public Location(NoDBLocation location, Waste waste)
        {
            this.LongitudeDD = location.LongitudeDD;
            this.LatitudeDD = location.LatitudeDD;
            this.LongitudeRadians = location.LongitudeRadians;
            this.LatitudeRadians = location.LatitudeRadians;
            this.Waste = waste;
        }

        public Waste Waste { get; }
        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public double LongitudeRadians { get; }
        public double LatitudeRadians { get; }
    }
}

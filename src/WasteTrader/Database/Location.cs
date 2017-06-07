using Starcounter;
using WasteTrader.MathUtils;
using System.Linq;

namespace WasteTrader.Database
{
    [Database]
    public class Location : ILocation
    {
        public Waste Waste => Db.SQL<Waste>("SELECT w FROM WasteTrader.Database.Waste w WHERE w.Location = ?", this).FirstOrDefault();
        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public double LongitudeRadians => GeographyMath.DegreesToRadians(LongitudeDD);
        public double LatitudeRadians => GeographyMath.DegreesToRadians(LatitudeDD);
    }
}

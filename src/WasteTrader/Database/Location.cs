using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using WasteTrader.MathUtils;

namespace WasteTrader.Database
{
    [Database]
    public class Location
    {
        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public IWaste Waste { get; }
        public double LongitudeRadians => GeographyMath.DegreesToRadians(LongitudeDD);
        public double LatitudeRadians => GeographyMath.DegreesToRadians(LatitudeDD);
    }
}

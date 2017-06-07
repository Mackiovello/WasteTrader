using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.MathUtils
{
    public interface ILocation
    {
        double LongitudeDD { get; set; }
        double LatitudeDD { get; set; }
        double LongitudeRadians { get; }
        double LatitudeRadians { get; }
    }
}

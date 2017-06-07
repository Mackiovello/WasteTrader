﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.MathUtils
{
    public class NoDBLocation : ILocation
    {
        public NoDBLocation(double longitudeDD, double latitudeDD)
        {
            this.LongitudeDD = longitudeDD;
            this.LatitudeDD = latitudeDD;
        }

        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public double LongitudeRadians => GeographyMath.DegreesToRadians(LongitudeDD);
        public double LatitudeRadians => GeographyMath.DegreesToRadians(LatitudeDD);
    }
}
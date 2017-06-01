using Starcounter;
using System;

namespace WasteTrader.Database
{
    [Database]
    public class Waste
    {
        public Waste()
        {
            this.EntryTime = DateTime.UtcNow;
        }

        public string Description { get; set; }
        public long Quantity { get; set; }
        public sbyte UnitMetricPrefixPower { get; set; }
        public byte Unit { get; set; }
        public DateTime EntryTime { get; private set; }
        public decimal LatitudeDD { get; set; }
        public decimal LongitudeDD { get; set; }
        public string LocationName { get; set; }
    }
}

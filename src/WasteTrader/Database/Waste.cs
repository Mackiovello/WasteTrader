using System;
using Starcounter;
using Simplified.Ring3;

namespace WasteTrader.Database
{
    public enum Unit
    {
        Meter,
        Kilometer,
        Kilogram,
        Tonne,
        SquareMeter,
        CubicMeter
    }

    [Database]
    public class Waste
    {
        public Waste()
        {
            this.EntryTime = DateTime.UtcNow;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryTime { get; }
        public Unit Unit { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public SystemUser User { get; set; }
        public bool Active { get; set; }
        public string Key => this.GetObjectID();
    }
}

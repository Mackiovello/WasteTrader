using System;
using Starcounter;

namespace WasteTrader.Database
{
    public abstract class Waste : IWaste
    {
        public Waste()
        {
            this.EntryTime = DateTime.UtcNow;
        }

        public string Description { get; set; }
        public long Quantity { get; set; }
        public sbyte UnitMetricPrefixPower { get; set; }
        public byte Unit { get; set; }

        public DateTime EntryTime { get; }
        
        public int Category { get; set; }
        public Location Location
        {
            get => Db.SQL<Location>("SELECT l FROM WasteTrader.Location WHERE l.Waste = ?", this).First;
        }
        public long Price { get; set; }
        public string Name { get; set; }
    }
}

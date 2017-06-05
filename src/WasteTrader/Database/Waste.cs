using System;
using Starcounter;
using System.Linq;

namespace WasteTrader.Database
{
    public enum UnitType
    {
        Mass = 1,
        Length = 2,
        Area = 3,
        Volume = 4
    }

    [Database]
    public class Waste
    {
        public Waste()
        {
            this.EntryTime = DateTime.UtcNow;
        }

        public string Description { get; set; }
        public long Quantity { get; set; }
        public int UnitMetricPrefixPower { get; set; }
        public UnitType Unit { get; set; }

        public DateTime EntryTime { get; }
        
        public int Category { get; set; }
        public Location Location => Db.SQL<Location>($"SELECT w FROM {nameof(Location)} WHERE w.{typeof(Waste)} = ?", this).FirstOrDefault();
        public long Price { get; set; }
        public string Name { get; set; }
    }
}

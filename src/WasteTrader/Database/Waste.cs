using System;
using Starcounter;
using System.Linq;
using WasteTrader.Measurements;
using WasteTrader.MathUtils;

namespace WasteTrader.Database
{
    public enum UnitType
    {
        Mass,
        Length,
        Area,
        Volume
    }

    [Database]
    public class Waste
    {
        public Waste(NoDBLocation location)
        {
            this.EntryTime = DateTime.UtcNow;
            new Location(location, this);
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public long Quantity { get; set; }
        public int UnitMetricPrefixPower { get; set; }
        public UnitType Unit { get; set; }
        public IMeasurement Measurement => MeasurementReader.Read(this);
        public DateTime EntryTime { get; }
        
        public Location Location => Db.SQL<Location>($"SELECT l FROM {nameof(Location)} l WHERE l.{nameof(Location.Waste)} = ?", this).FirstOrDefault();
        public long Price { get; set; }
        public Client User { get; set; }
        public string Key => this.GetObjectID();
        public bool Active { get; set; }
    }
}

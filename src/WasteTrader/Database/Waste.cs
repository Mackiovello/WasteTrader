using System;
using Starcounter;
using System.Linq;
using WasteTrader.Measurements;
using WasteTrader.MathUtils;
using Simplified.Ring3;

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
        public Waste(NoDBLocation location)
        {
            this.EntryTime = DateTime.UtcNow;
            new Location(location, this);
        }

        public string Description { get; set; }
        public long Quantity { get; set; }
        public int UnitMetricPrefixPower { get; set; }
        public UnitType Unit { get; set; }
        public IMeasurement Measurement => MeasurementReader.Read(this);
        public DateTime EntryTime { get; }
        
        public int Category { get; set; }
        public Location Location => Db.SQL<Location>($"SELECT l FROM {nameof(Location)} l WHERE l.{nameof(Location.Waste)} = ?", this).FirstOrDefault();
        public long Price { get; set; }
        public string Name { get; set; }
        public SystemUser User { get; set; }
        public string UserName => User.Name;
        public string UserURI => "/Waste2Value/user/" + UserName;
    }
}

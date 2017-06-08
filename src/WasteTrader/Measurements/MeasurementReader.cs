using System;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Measurements
{
    public static class MeasurementReader
    {

        private static readonly Dictionary<UnitType, Func<long, int, IMeasurement>> Types = new Dictionary<UnitType, Func<long, int, IMeasurement>>
        {
            { UnitType.Mass, (long quantity, int prefixpower) => (IMeasurement) new Mass(quantity, prefixpower)},
            { UnitType.Length, (long quantity, int prefixpower) => (IMeasurement) new Length(quantity, prefixpower)},
            { UnitType.Area, (long quantity, int prefixpower) => (IMeasurement) new Area(quantity, prefixpower)},
            { UnitType.Volume, (long quantity, int prefixpower) => (IMeasurement) new Volume(quantity, prefixpower)}
        };

        public static IMeasurement Read(Waste waste)
        {
            return Read(waste.Unit, waste.Quantity, waste.UnitMetricPrefixPower);
        }

        public static IMeasurement Read(UnitType unit, long quantity, int unitMetricPrefixPower)
        {
            return Types[unit].Invoke(quantity, unitMetricPrefixPower);
        }
    }
}

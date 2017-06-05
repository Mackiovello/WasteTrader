using System;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Measurements
{
    public static class MeasurementReader
    {

        private static readonly Dictionary<UnitType, Func<long, int, IMeasurement<object>>> Types = new Dictionary<UnitType, Func<long, int, IMeasurement<object>>>
        {
            { UnitType.Mass, (long quantity, int prefixpower) => (IMeasurement<Object>) new Mass(quantity,prefixpower)},
            { UnitType.Length, (long quantity, int prefixpower) => (IMeasurement<Object>) new Length(quantity, prefixpower) },
            { UnitType.Area, (long quantity, int prefixpower) => (IMeasurement<Object>) new Area(quantity,prefixpower)},
            { UnitType.Volume, (long quantity, int prefixpower) => (IMeasurement<Object>) new Volume(quantity,prefixpower)}
        };

        public static IMeasurement<Object> Read(Waste waste)
        {
            return Read(waste.Unit, waste.Quantity, waste.UnitMetricPrefixPower);
        }

        public static IMeasurement<Object> Read(UnitType unit, long quantity, int unitMetricPrefixPower)
        {
            return Types[unit].Invoke(quantity, unitMetricPrefixPower);
        }
    }
}

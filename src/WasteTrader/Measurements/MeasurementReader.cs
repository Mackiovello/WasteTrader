using System;
using WasteTrader.Database;

namespace WasteTrader.Measurements
{
    public static class MeasurementReader
    {
        public static Tuple<IMeasurement<Object>, Type> Read(IWaste waste)
        {
            return Read(waste.Unit, waste.Quantity, waste.UnitMetricPrefixPower);
        }

        public static Tuple<IMeasurement<Object>,Type> Read(byte unit, long quantity, sbyte unitMetricPrefixPower)
        {
            switch (unit)
            {
                //Mass
                case 1: return new Tuple<IMeasurement<Object>, Type>((IMeasurement<Object>)new Mass(quantity, unitMetricPrefixPower), typeof(Mass));

                //Length
                case 2: return new Tuple<IMeasurement<Object>, Type>((IMeasurement<Object>)new Length(quantity, unitMetricPrefixPower), typeof(Length));

                //Area
                case 3: return new Tuple<IMeasurement<Object>, Type>((IMeasurement<Object>)new Area(quantity, unitMetricPrefixPower), typeof(Area));

                //Volume
                case 4: return new Tuple<IMeasurement<Object>, Type>((IMeasurement<Object>)new Volume(quantity, unitMetricPrefixPower), typeof(Volume));

                default: throw new ArgumentOutOfRangeException("Unit " + unit + " is not a known measurement type.");
            }
        }
    }
}

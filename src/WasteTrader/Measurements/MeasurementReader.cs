using System;
using WasteTrader.Database;

namespace WasteTrader.Measurements
{
    public static class MeasurementReader
    {
        public static Tuple<IMeasurement<Object>, Type> Read(Waste waste)
        {
            return Read(waste.Unit, waste.Quantity, waste.UnitMetricPrefixPower);
        }

        public static Tuple<IMeasurement<Object>,Type> Read(int unit, long quantity, int unitMetricPrefixPower)
        {
            switch (unit)
            {
                //Mass
                case 1:
                    var mass = (IMeasurement<Object>) new Mass(quantity, unitMetricPrefixPower);
                    return new Tuple<IMeasurement<Object>, Type>(mass, typeof(Mass));

                //Length
                case 2:
                    var length = (IMeasurement<Object>)new Length(quantity, unitMetricPrefixPower);
                    return new Tuple<IMeasurement<Object>, Type>(length, typeof(Length));

                //Area
                case 3:
                    var area = (IMeasurement<Object>)new Area(quantity, unitMetricPrefixPower);
                    return new Tuple<IMeasurement<Object>, Type>(area, typeof(Area));

                //Volume
                case 4:
                    var volume = (IMeasurement<Object>)new Volume(quantity, unitMetricPrefixPower);
                    return new Tuple<IMeasurement<Object>, Type>(volume, typeof(Volume));

                default: throw new ArgumentOutOfRangeException("Unit " + unit + " is not a known measurement type.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using WasteTrader.MathUtils;

namespace WasteTrader.Measurements
{
    public abstract class Measurement : IMeasurement
    {
        public long Quantity { get; set; }
        public int UnitMetricPrefixPower { get; set; }
        public abstract Dictionary<int, Unit> Symbols { get; }
        public long Value => this.Quantity * LongMath.Pow(10, UnitMetricPrefixPower);

        public override string ToString()
        {
            Symbols.TryGetValue(UnitMetricPrefixPower, out Unit unit);

            if (unit != null)
                return CalcValue(unit) + " " + unit.Text;

            else
                return CalcValue(new Unit("E", 0)) + " " + "E" + UnitMetricPrefixPower;
        }

        public void ConvertOptimal()
        {
            string valueString = Value.ToString();
            int lengthDifference = (valueString.Length - valueString.TrimEnd(new Char[] { '0' }).Length);
            if (lengthDifference == 0)
                return;

            int start = UnitMetricPrefixPower + lengthDifference;

            for (int i = start; i > UnitMetricPrefixPower; i--)
            {
                Symbols.TryGetValue(i, out Unit unit);
                if (unit != null)
                {
                    UnitMetricPrefixPower = i;
                    Quantity /= LongMath.Pow(10, start - i);
                }
            }
        }

        public long CalcValue(Unit unit)
        {
            long mult = LongMath.Pow(10, UnitMetricPrefixPower + unit.Offset);
            return Quantity * mult;
        }
    }
}

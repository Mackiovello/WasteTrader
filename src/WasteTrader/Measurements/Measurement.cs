using System;
using System.Collections.Generic;
using WasteTrader.MathUtils;

namespace WasteTrader.Measurements
{
    public abstract class Measurement<T> : IMeasurement<T> where T : Measurement<T>
    {
        public long Quantity { get; set; }
        public int UnitMetricPrefixPower { get; set; }
        public abstract Dictionary<int, Unit> Symbols { get; }
        public long Value => this.Quantity * LongMath.Pow(10, UnitMetricPrefixPower);

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is T other)
                return Value.CompareTo(other.Value);

            else
                throw new ArgumentException("Object is not of type " + typeof(T).FullName);
        }

        public bool Equals(T other)
        {
            return Equals(this, other);
        }

        public virtual bool Equals(T x, T y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null | y == null)
                return false;
            else if (x.GetType() != y.GetType())
                return false;
            else if (x.Value.Equals(y.Value))
                return true;
            else
                return false;
        }

        public virtual int GetHashCode(T obj)
        {
            return (obj.Value ^ obj.GetType().GetHashCode()).GetHashCode();
        }

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

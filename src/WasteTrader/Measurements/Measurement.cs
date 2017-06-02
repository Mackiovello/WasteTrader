using System;
using System.Collections.Immutable;
using WasteTrader.MathUtils;

namespace WasteTrader.Measurements
{
    public abstract class Measurement<T> : IMeasurement<T> where T : Measurement<T>
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            T other = obj as T;
            if (other != null) return Value.CompareTo(other.Value);
            else throw new ArgumentException("Object is not of type " + typeof(T).FullName);
        }

        public bool Equals(T other)
        {
            return Equals(this, other);
        }

        public virtual bool Equals(T x, T y)
        {
            if (x == null && y == null) return true;
            else if (x == null | y == null) return false;
            else if (x.GetType() != y.GetType()) return false;
            else if (x.Value.Equals(y.Value)) return true;
            else return false;
        }

        public virtual int GetHashCode(T obj)
        {
            return (obj.Value ^ obj.GetType().GetHashCode()).GetHashCode();
        }

        public long Value
        {
            get
            {
                var mult = LongMath.Pow(10,UnitMetricPrefixPower);
                return Quantity * mult;
            }
        }

        public override string ToString()
        {
            var unit = Symbols[UnitMetricPrefixPower];
            return CalcValue(unit) + " " + unit.Text;
        }
        
        public void ConvertOptimal()
        {
            throw new NotImplementedException();
        }

        public long CalcValue(Unit unit)
        {
            var mult = LongMath.Pow(10, UnitMetricPrefixPower + unit.Offset);
            return Quantity * mult;
        }

        public long Quantity { get; set; }
        public sbyte UnitMetricPrefixPower { get; set; }
        public abstract IImmutableDictionary<sbyte, Unit> Symbols { get; }
    }
}

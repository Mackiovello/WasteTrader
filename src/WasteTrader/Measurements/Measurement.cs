using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Collections.Immutable;

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

        public BigInteger Value
        {
            get
            {
                var mult = BigInteger.Pow(10, UnitMetricPrefixPower);
                return Quantity * mult;
            }
        }

        public override string ToString()
        {
            var unit = Symbols[UnitMetricPrefixPower];
            return CalcValue(unit) + " " + unit.Text;
        }
        
        public void Optimise()
        {
            throw new NotImplementedException();
        }

        public BigInteger CalcValue(Unit unit)
        {
            var mult = BigInteger.Pow(10, UnitMetricPrefixPower + unit.Offset);
            return Quantity * mult;
        }

        public long Quantity { get; set; }
        public sbyte UnitMetricPrefixPower { get; set; }
        public abstract IImmutableDictionary<sbyte, Unit> Symbols { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public abstract class Measurement<T> : IMeasurement<T> where T : Measurement<T>
    {
        public abstract object Clone();
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

        public virtual Tuple<string, sbyte> Unit(sbyte prefix)
        {
            return Unit(prefix, MetricPrefixes.Symbol);
        }

        public virtual Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte,string> dictionary)
        {
            string mpref = "";
            bool found = dictionary.TryGetValue(prefix, out mpref);
            if (found) return new Tuple<string, sbyte>(mpref, 0);
            else return new Tuple<string, sbyte>("E" + prefix, 0);
        }

        public BigInteger Value
        {
            get
            {
                return calcValue(Quantity, UnitMetricPrefixPower);
            }
        }

        public static BigInteger calcValue(long quantity, sbyte unitMetricPrefixPower)
        {
            var mult = BigInteger.Pow(10, unitMetricPrefixPower);
            return quantity * mult;
        }

        public override string ToString()
        {
            var unit = Unit(UnitMetricPrefixPower);
            var value = calcValue(Quantity, unit.Item2);
            return value.ToString() + " " + unit.Item1;
        }

        public long Quantity { get; set; }
        public sbyte UnitMetricPrefixPower { get; set; }
    }
}

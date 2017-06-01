using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Volume : Measurement<Volume>
    {
        public Volume(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public static ImmutableDictionary<sbyte, string> Dictionary = MetricPrefixes.Symbol.ToImmutableDictionary(p => (sbyte) (p.Key * 3), p => p.Value);

        public override Tuple<string, sbyte> Unit(sbyte prefix)
        {
            return base.Unit(prefix, Dictionary);
        }

        public override Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte,string> dictionary)
        {
            if (prefix <= -3)
            {
                sbyte literPrefix = (sbyte)(prefix + 3);
                var bUnit = base.Unit(literPrefix, dictionary);
                var r = new Tuple<string, sbyte>(bUnit.Item1 + "l", (sbyte)(bUnit.Item2 + 3));
                return r;
            }
            else
            {
                var unit = base.Unit(prefix);
                return new Tuple<string, sbyte>(unit.Item1 + "m³", unit.Item2);
            }
        }

        public override object Clone()
        {
            return new Volume(Quantity, UnitMetricPrefixPower);
        }
    }
}

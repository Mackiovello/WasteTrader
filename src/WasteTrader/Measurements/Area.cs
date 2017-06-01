using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Area : Measurement<Area>
    {
        public static ImmutableDictionary<sbyte, string> Dictionary = MetricPrefixes.Symbol.ToImmutableDictionary(p => (sbyte) (p.Key * 2), p => p.Value);


        public Area(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        public override Tuple<string, sbyte> Unit(sbyte prefix)
        {
            return base.Unit(prefix,Dictionary);
        }

        public override Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte,string> dictionary)
        {
            var unit = base.Unit(prefix, dictionary);
            return new Tuple<string, sbyte>(unit.Item1 + "m²", unit.Item2);
        }

        public override object Clone()
        {
            return new Area(Quantity, UnitMetricPrefixPower);
        }
    }
}

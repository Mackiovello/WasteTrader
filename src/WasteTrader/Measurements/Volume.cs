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
        private static ImmutableDictionary<sbyte, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> kvp)
        {
            return (sbyte)(kvp.Key * 3);
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> kvp)
        {
            if (kvp.Key <= -3) return new Unit(kvp.Value + "l", 3);
            else return new Unit(kvp.Value + "m³", 0);
        }

        public Volume(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

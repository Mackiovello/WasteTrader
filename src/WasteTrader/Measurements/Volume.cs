using System.Collections.Generic;
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

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

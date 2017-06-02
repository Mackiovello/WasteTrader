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

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> pair)
        {
            return (sbyte)(pair.Key * 3);
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> pair)
        {
            if (pair.Key <= -3) return new Unit(pair.Value + "l", 3);
            else return new Unit(pair.Value + "m³", 0);
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

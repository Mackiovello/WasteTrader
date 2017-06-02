using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Length : Measurement<Length>
    {

        private static ImmutableDictionary<sbyte, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> kvp)
        {
            return kvp.Key;
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> kvp)
        {
            return new Unit(kvp.Value + "m", 0);
        }

        public Length(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

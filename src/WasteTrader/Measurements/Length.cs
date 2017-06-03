using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Length : Measurement<Length>
    {
        public Length(long Quantity, int UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        private static ImmutableDictionary<int, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return pair.Key;
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            return new Unit(pair.Value + "m", 0);
        }


        public override IImmutableDictionary<int, Unit> Symbols => Units;
    }
}

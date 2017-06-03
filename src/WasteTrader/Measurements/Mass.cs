using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Mass : Measurement<Mass>
    {
        public Mass(long Quantity, int UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        private static ImmutableDictionary<int, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return pair.Key;
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            if (pair.Key >= 6) return new Unit(pair.Value + "t", -6);
            else return new Unit(pair.Value + "g", 0);
        }

        public override IImmutableDictionary<int, Unit> Symbols => Units;
    }
}

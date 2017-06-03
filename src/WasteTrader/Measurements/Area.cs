using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Area : Measurement<Area>
    {
        public Area(long Quantity, int UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        private static ImmutableDictionary<int, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return (int)(pair.Key * 2);
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            return new Unit(pair.Value + "m²", 0);
        }

        public override IImmutableDictionary<int, Unit> Symbols => Units;
    }
}

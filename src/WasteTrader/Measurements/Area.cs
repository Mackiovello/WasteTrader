using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Area : Measurement<Area>
    {
        public Area(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        private static ImmutableDictionary<sbyte, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> pair)
        {
            return (sbyte)(pair.Key * 2);
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> pair)
        {
            return new Unit(pair.Value + "m²", 0);
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

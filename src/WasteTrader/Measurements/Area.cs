using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Area : Measurement<Area>
    {
        private static ImmutableDictionary<sbyte, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> kvp)
        {
            return (sbyte)(kvp.Key * 2);
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> kvp)
        {
            return new Unit(kvp.Value + "m²", 0);
        }

        public Area(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

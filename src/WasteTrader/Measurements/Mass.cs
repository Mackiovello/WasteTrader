using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Mass : Measurement<Mass>
    {

        private static ImmutableDictionary<sbyte, Unit> Units = MetricPrefixes.Symbol.ToImmutableDictionary(ConvertKey, ConvertValue);

        private static sbyte ConvertKey(KeyValuePair<sbyte, string> kvp)
        {
            return kvp.Key;
        }

        private static Unit ConvertValue(KeyValuePair<sbyte, string> kvp)
        {
            if (kvp.Key >= 6) return new Unit(kvp.Value + "t", -6);
            else return new Unit(kvp.Value + "g", 0);
        }

        public Mass(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public override IImmutableDictionary<sbyte, Unit> Symbols => Units;
    }
}

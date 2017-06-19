using System.Collections.Generic;
using System.Linq;

namespace WasteTrader.Measurements
{
    public class Mass : Measurement
    {
        public Mass(long Quantity, int UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public static Dictionary<int, Unit> Units = MetricPrefixes.Symbol.ToDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return pair.Key;
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            if (pair.Key >= 6)
                return new Unit(pair.Value + "t", -6);
            else
                return new Unit(pair.Value + "g", 0);
        }

        public override Dictionary<int, Unit> Symbols => Units;
    }
}

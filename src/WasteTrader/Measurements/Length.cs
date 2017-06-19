using System.Collections.Generic;
using System.Linq;

namespace WasteTrader.Measurements
{
    public class Length : Measurement
    {
        public Length(long Quantity, int UnitMetricPrefixPower)
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
            return new Unit(pair.Value + "m", 0);
        }

        public override Dictionary<int, Unit> Symbols => Units;
    }
}

using System.Collections.Generic;
using System.Linq;

namespace WasteTrader.Measurements
{
    public class Volume : Measurement
    {
        public Volume(long Quantity, int UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public static Dictionary<int, Unit> Units = MetricPrefixes.Symbol.ToDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return pair.Key * 3;
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            if (pair.Key <= -3)
                return new Unit(pair.Value + "l", 3);
            else
                return new Unit(pair.Value + "m³", 0);
        }

        public override Dictionary<int, Unit> Symbols => Units;
    }
}

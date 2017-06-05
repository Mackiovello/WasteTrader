using System.Collections.Generic;
using System.Linq;

namespace WasteTrader.Measurements
{
    public class Area : Measurement<Area>
    {
        public Area(long Quantity, int UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        private static Dictionary<int, Unit> Units = MetricPrefixes.Symbol.ToDictionary(ConvertKey, ConvertValue);

        private static int ConvertKey(KeyValuePair<int, string> pair)
        {
            return (pair.Key * 2);
        }

        private static Unit ConvertValue(KeyValuePair<int, string> pair)
        {
            return new Unit(pair.Value + "m²", 0);
        }

        public override Dictionary<int, Unit> Symbols => Units;
    }
}

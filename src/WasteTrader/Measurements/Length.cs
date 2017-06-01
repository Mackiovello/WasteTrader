using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public class Length : Measurement<Length>
    {
        public Length(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.Quantity = Quantity;
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
        }

        public override Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte,string> dictionary)
        {
            var unit = base.Unit(prefix, dictionary);
            return new Tuple<string, sbyte>(unit.Item1 + "m", unit.Item2);
        }

        public override object Clone()
        {
            return new Length(Quantity, UnitMetricPrefixPower);
        }
    }
}

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
        public Mass(long Quantity, sbyte UnitMetricPrefixPower)
        {
            this.UnitMetricPrefixPower = UnitMetricPrefixPower;
            this.Quantity = Quantity;
        }

        public override Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte, string> dictionary)
        {
            if (prefix > 6)
            {
                sbyte tonPrefix = (sbyte)(prefix - 6);
                var unit = base.Unit(tonPrefix, dictionary);
                var r = new Tuple<string, sbyte>(unit.Item1 + "t", (sbyte)(unit.Item2 - 6));
                return r;
            }
            else
            {
                var unit = base.Unit(prefix);
                return new Tuple<string, sbyte>(unit.Item1 + "g", unit.Item2);
            }
        }

        public override object Clone()
        {
            return new Mass(Quantity, UnitMetricPrefixPower);
        }
    }
}

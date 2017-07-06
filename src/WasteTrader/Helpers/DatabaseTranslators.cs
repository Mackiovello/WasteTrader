using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;

namespace WasteTrader.Helpers
{
    public static class DatabaseTranslator
    {
        public static Dictionary<Unit, string> UnitEnumToString = new Dictionary<Unit, string>()
        {
            { Unit.Meter, "meter" },
            { Unit.Kilometer, "kilometer" },
            { Unit.Kilogram, "kilogram" },
            { Unit.Tonne, "ton" },
            { Unit.SquareMeter, "kvadratmeter" },
            { Unit.CubicMeter, "kubikmeter" }
        };
    }
}

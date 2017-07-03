using Simplified.Ring3;
using Starcounter;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<Waste>
    {
        public string FormattedEntryTime => Data?.EntryTime.Date.ToString("d");
        public string FormattedQuantity => $"{Data.Quantity} {UnitEnumToString[Data.Unit]}";

        Dictionary<Unit, string> UnitEnumToString = new Dictionary<Unit, string>()
        {
            { Unit.Meter, "meter" },
            { Unit.Kilometer, "kilometer" },
            { Unit.Kilogram, "kilogram" },
            { Unit.Tonne, "ton" },
            { Unit.SquareMeter, "kvadratmeter" },
            { Unit.CubicMeter, "kubikmeter" }
        };

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<SystemUser>
        {

        }
    }
}
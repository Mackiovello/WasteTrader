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
            { Unit.Meter, "Meter" },
            { Unit.Kilometer, "Kilometer" },
            { Unit.Kilogram, "Kilogram" },
            { Unit.Tonne, "Ton" },
            { Unit.SquareMeter, "Kvadratmeter" },
            { Unit.CubicMeter, "Kubikmeter" }
        };

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Client>
        {

        }
    }
}
using Simplified.Ring3;
using Starcounter;
using System.Collections.Generic;
using WasteTrader.Database;
using WasteTrader.Helpers;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<Waste>
    {
        public string FormattedEntryTime => Data?.EntryTime.Date.ToString("d");
        public string FormattedQuantity => $"{Data.Quantity} {DatabaseTranslator.UnitEnumToString[Data.Unit]}";

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<SystemUser>
        {

        }
    }
}
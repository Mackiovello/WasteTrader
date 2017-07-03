using Simplified.Ring3;
using Starcounter;
using System;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WastePage : Json, IBound<Waste>
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

        private bool IsOwner
        {
            get
            {
                var user = SystemUser.GetCurrentSystemUser();
                if (user == null)
                    return false;

                return this.Data.User.Key == user.Key;
            }
        }

        public bool ShowDeleteButton => IsOwner && this.Active;

        void Handle(Input.DeleteTrigger action)
        {
            if (IsOwner)
            {
                this.RedirectUrl = $"/Waste2Value/user/{this.User.Username}";
                Db.Transact(() => this.Data.Active = false);
            }
        }

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<SystemUser>
        {

        }
    }
}
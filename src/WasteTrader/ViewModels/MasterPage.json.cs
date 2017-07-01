using Simplified.Ring3;
using Starcounter;
using WasteTrader.Api;
using WasteTrader.Helpers;

namespace WasteTrader.ViewModels
{
    partial class MasterPage : Json
    {
        internal void RefreshSignInState()
        {
            this.Drawer = Self.GET(PartialHandlers.partialPrefix + "drawer");
            SystemUser user = SystemUser.GetCurrentSystemUser();

            if (user == null)
                this.CurrentPage = Self.GET(PartialHandlers.partialPrefix + "Hitta");
            else
                this.CurrentPage = Self.GET($"{PartialHandlers.partialPrefix}user/{user.Username}");
        }
    }
}

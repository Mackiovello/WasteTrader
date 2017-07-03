using Simplified.Ring3;
using Starcounter;
using WasteTrader.Api;
using WasteTrader.Helpers;

namespace WasteTrader.ViewModels
{
    partial class MasterPage : Json
    {
        internal void RefreshSignInState<T>(T createdItem)
        {
            this.Drawer = Self.GET(PartialHandlers.partialPrefix + "drawer");
            SystemUser user = SystemUser.GetCurrentSystemUser();

            if (typeof(T) == typeof(SystemUser))
            {
                this.CurrentPage = Self.GET(PartialHandlers.partialPrefix + "Valkommen");
            }
            else
            {
                if (user == null)
                    this.CurrentPage = Self.GET(PartialHandlers.partialPrefix + "Hitta");
                else
                    this.CurrentPage = Self.GET($"{PartialHandlers.partialPrefix}user/{user.Username}");
            }
        }
    }
}

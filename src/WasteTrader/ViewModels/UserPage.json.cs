using Starcounter;
using Simplified.Ring3;
using System.Linq;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<SystemUser>
    {
        static UserPage()
        {
            DefaultTemplate.SellWastes.ElementType.InstanceType = typeof(SellWasteJson);
            DefaultTemplate.BuyWastes.ElementType.InstanceType = typeof(BuyWasteJson);
        }
        public string Html => "/WasteTrader/views/UserPage.html";
    }
}

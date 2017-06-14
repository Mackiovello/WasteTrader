using Starcounter;
using Simplified.Ring3;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IExplicitBound<SystemUser>
    {
        static UserPage()
        {
            DefaultTemplate.SellWastes.ElementType.InstanceType = typeof(SellWasteJson);
            DefaultTemplate.BuyWastes.ElementType.InstanceType = typeof(BuyWasteJson);
        }

        public SellWasteJson SellWastes => null;
        public BuyWasteJson BuyWastes => null;
        public string Html => "/WasteTrader/views/UserPage.html";
    }
}

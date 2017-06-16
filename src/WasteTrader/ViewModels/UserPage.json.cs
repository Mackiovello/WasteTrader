using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<Database.Client>
    {
        static UserPage()
        {
            DefaultTemplate.SellWastes.ElementType.InstanceType = typeof(SellWasteJson);
            DefaultTemplate.BuyWastes.ElementType.InstanceType = typeof(BuyWasteJson);
        }
    }
}

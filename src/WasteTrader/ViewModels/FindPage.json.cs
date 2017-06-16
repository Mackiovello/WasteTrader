using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class FindPage : Json
    {
        static FindPage()
        {
            DefaultTemplate.BuyWaste.ElementType.InstanceType = typeof(BuyWasteJson);
            DefaultTemplate.SellWaste.ElementType.InstanceType = typeof(SellWasteJson);
        }
    }
}

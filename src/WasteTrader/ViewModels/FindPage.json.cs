using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class FindPage : Json
    {
        static FindPage()
        {
            DefaultTemplate.WasteEntries.ElementType.InstanceType = typeof(WasteEntry);
        }
    }
}

using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<Database.Client>
    {
        static UserPage()
        {
            DefaultTemplate.WasteEntries.ElementType.InstanceType = typeof(WasteEntry);
        }
    }
}

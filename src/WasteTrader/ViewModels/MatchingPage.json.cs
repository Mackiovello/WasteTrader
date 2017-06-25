using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class MatchingPage : Json
    {
        static MatchingPage()
        {
            DefaultTemplate.Matches.ElementType.InstanceType = typeof(WasteEntry);
        }
    }
}

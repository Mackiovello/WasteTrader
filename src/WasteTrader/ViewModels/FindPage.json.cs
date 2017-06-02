using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class FindPage : Json
    {
        [FindPage_json.Waste]
        partial class FindWastePartial : Json, IExplicitBound<Database.Waste>
        {
            public string FormattedDate => this.Data.EntryTime.Date.ToString("d");
        }
    }
}

using Starcounter;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class FindPage : Json
    {
        [FindPage_json.Waste]
        partial class FindWastePartial : Json, IExplicitBound<Database.Waste>
        {

        }
    }
}

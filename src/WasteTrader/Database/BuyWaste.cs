using Starcounter;
using WasteTrader.MathUtils;

namespace WasteTrader.Database
{
    [Database]
    public class BuyWaste : Waste
    {
        public BuyWaste(NoDBLocation location) : base(location)
        {
        }
    }
}

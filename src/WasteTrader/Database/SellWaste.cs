using Starcounter;
using WasteTrader.MathUtils;

namespace WasteTrader.Database
{
    [Database]
    public class SellWaste : Waste
    {
        public SellWaste(NoDBLocation location) : base(location)
        {
        }
    }
}

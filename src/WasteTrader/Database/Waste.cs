using Starcounter;

namespace WasteTrader.Database
{
    [Database]
    public class Waste
    {
        public string Description { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }
}

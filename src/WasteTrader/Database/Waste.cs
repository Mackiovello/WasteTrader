using Starcounter;

namespace WasteTrader.Database
{
    public enum Unit
    {
        Kg,
        m2,
        m3,
    }

    [Database]
    public class Waste
    {
        public string Description { get; set; }
        public double Quantity { get; set; }
        public Unit Unit { get; set; }
    }
}

using Starcounter;
using System;

namespace WasteTrader.Database
{
    [Database]
    public class Waste
    {
        public Waste()
        {
            this.EntryTime = DateTime.Now;
        }

        public string Description { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime EntryTime { get; private set; }
    }
}

using System;
using Starcounter;

namespace WasteTrader.Database
{
    [Database]
    public class Waste
    {
        public Waste()
        {
            this.EntryTime = DateTime.UtcNow;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryTime { get; }
        
        public long Price { get; set; }
        public Client User { get; set; }
        public string Key => this.GetObjectID();
        public bool Active { get; set; }
    }
}

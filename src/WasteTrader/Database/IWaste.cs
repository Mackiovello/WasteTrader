using System;

namespace WasteTrader.Database
{
    public interface IWaste
    {
        string Name { get; set; }
        string Description { get; set; }
        long Quantity { get; set; }
        int UnitMetricPrefixPower { get; set; }
        int Unit { get; set; }
        long Price { get; set; }
        DateTime EntryTime { get; }
        int Category { get; set; }
        Location Location { get; }
    }
}

using System;

namespace WasteTrader.Database
{
    public interface IWaste
    {
        string Description { get; set; }
        long Quantity { get; set; }
        sbyte UnitMetricPrefixPower { get; set; }
        byte Unit { get; set; }
        long Price { get; set; }
        DateTime EntryTime { get; }
        int Category { get; set; }
        Location Location { get; }
    }
}

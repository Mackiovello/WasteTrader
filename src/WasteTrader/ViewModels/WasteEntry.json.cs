using Starcounter;
using WasteTrader.Measurements;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<Waste>
    {
        public string FormattedEntryTime => Data?.EntryTime.Date.ToString("d");

        public string Amount => MeasurementReader.Read((UnitType) Unit, Quantity, (int) UnitMetricPrefixPower).ToString();

        public decimal RawAmount => MeasurementReader.Read((UnitType)Unit, Quantity, (int)UnitMetricPrefixPower).Value;

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Client>
        {

        }
    }
}
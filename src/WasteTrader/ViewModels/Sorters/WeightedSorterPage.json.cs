using Starcounter;
using WasteTrader.Matchmaking.Sorters;
using System.Linq;

namespace WasteTrader.ViewModels.Sorters
{
    partial class WeightedSorterPage : Json
    {
        public static implicit operator WeightedSorter(WeightedSorterPage page)
        {
            var sorters = page.Sorters.AsParallel().ToDictionary(s => (IMatchSorter) s.Sorter, s => (double) s.Weight);
            return new WeightedSorter(page.DescendingOrder, sorters);
        }

        void Handle(Input.AddSorter action)
        {
            SortersElementJson newSorter = new SortersElementJson();
            switch (action.Value)
            {
                case "DateSorter":
                    newSorter.Sorter = new DateSorterPage();
                    newSorter.Name = "Date sorter";
                    break;
                case "DistanceSorter":
                    newSorter.Sorter = new DistanceSorterPage();
                    newSorter.Name = "Distance Sorter";
                    break;
                case "PPUSorter":
                    newSorter.Sorter = new PricePerUnitSorterPage();
                    newSorter.Name = "Price per unit Sorter";
                    break;
                case "PriceSorter":
                    newSorter.Sorter = new PriceSorterPage();
                    newSorter.Name = "Price Sorter";
                    break;
                case "QuantitySorter":
                    newSorter.Sorter = new QuantitySorterPage();
                    newSorter.Name = "Quantity Sorter";
                    break;
                default: return;
            }
            this.Sorters.Add(newSorter);
        }
    }
}

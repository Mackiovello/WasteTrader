using Starcounter;
using WasteTrader.Matchmaking.Sorters;
using System.Linq;
using System;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.ViewModels.Sorters
{
    partial class WeightedSorterPage : Json, IMatchSorter
    {
        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var sorters = Sorters.AsParallel().ToDictionary(s => (IMatchSorter)s.Sorter, s => (double) s.Weight);
            WeightedSorter sorter = new WeightedSorter(DescendingOrder, sorters);
            return sorter.Sort(waste);
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

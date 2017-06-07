using Starcounter;
using WasteTrader.ViewModels.Sorters;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.Matchmaking;
using System;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class MatchParametersPage : Json
    {
        static MatchParametersPage()
        {
            DefaultTemplate.MaxDistance.InstanceType = typeof(double);
            DefaultTemplate.MinDistance.InstanceType = typeof(double);
            DefaultTemplate.PricePerUnitLimit.InstanceType = typeof(double);
        }

        public int MaxMatches { get; set; }

        void Handle(Input.SubmitTrigger action)
        {
            
        }

        void Handle(Input.SelectedSorter action)
        {
            switch (action.Value)
            {
                case "DateSorter":
                    Sorter = new DateSorterPage();
                    break;
                case "DistanceSorter":
                    Sorter = new DistanceSorterPage();
                    break;
                case "PPUSorter":
                    Sorter = new PricePerUnitSorterPage();
                    break;
                case "PriceSorter":
                    Sorter = new PriceSorterPage();
                    break;
                case "QuantitySorter":
                    Sorter = new QuantitySorterPage();
                    break;
                case "WeightedSorter":
                    Sorter = new WeightedSorterPage();
                    break;
            }
        }
    }
}

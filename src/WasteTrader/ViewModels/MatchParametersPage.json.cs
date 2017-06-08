using Starcounter;
using WasteTrader.ViewModels.Sorters;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.Matchmaking;
using System;
using WasteTrader.Database;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels
{
    partial class MatchParametersPage : Json
    {
        static MatchParametersPage()
        {
            DefaultTemplate.MaxDistance.InstanceType = typeof(double);
            DefaultTemplate.MinDistance.InstanceType = typeof(double);
            DefaultTemplate.PricePerUnitLimit.InstanceType = typeof(double);
            DefaultTemplate.LongitudeDD.InstanceType = typeof(double);
            DefaultTemplate.LatitudeDD.InstanceType = typeof(double);
        }

        public Action<Waste[]> WasteDump { protected get; set; }

        public Type SorterType { get; set; }
        void Handle(Input.SubmitTrigger action)
        {
            BasicMatchParameters matchParams = new BasicMatchParameters
            {
                MaxDistance = MaxDistance,
                MinDistance = MinDistance,
                MaxMatches = (int)MaxMatches,
                PricePerUnitLimit = PricePerUnitLimit,
                MaxQuantity = MaxQuantity,
                MinQuantity = MinQuantity,
                UnitType = 0,
                SearchFrom = new NoDBLocation(LongitudeDD, LatitudeDD),
                Sorter = (IMatchSorter)Sorter,
            };
            SimpleMatchMaker matchMaker = new SimpleMatchMaker();
            Waste[] matches = matchMaker.Match(matchParams, Db.SQL<Waste>($"SELECT i FROM {typeof(Waste)} i"));
            WasteDump(matches);
        }


        void Handle(Input.SelectedSorter action)
        {
            switch (action.Value)
            {
                case "DateSorter":
                    Sorter = new DateSorterPage();
                    SorterType = typeof(DateSorter);
                    break;
                case "DistanceSorter":
                    Sorter = new DistanceSorterPage();
                    SorterType = typeof(DistanceSorter);
                    break;
                case "PPUSorter":
                    Sorter = new PricePerUnitSorterPage();
                    SorterType = typeof(PricePerUnitSorter);
                    break;
                case "PriceSorter":
                    Sorter = new PriceSorterPage();
                    SorterType = typeof(PriceSorterPage);
                    break;
                case "QuantitySorter":
                    Sorter = new QuantitySorterPage();
                    SorterType = typeof(QuantitySorter);
                    break;
                case "WeightedSorter":
                    Sorter = new WeightedSorterPage();
                    SorterType = typeof(WeightedSorter);
                    break;
            }
        }
    }
}

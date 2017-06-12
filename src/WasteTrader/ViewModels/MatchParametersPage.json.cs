using Starcounter;
using WasteTrader.ViewModels.Sorters;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.Matchmaking;
using System;
using WasteTrader.Database;
using WasteTrader.MathUtils;
using System.Collections.Generic;

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

        protected readonly IDictionary<string, Func<Json>> sorters = new Dictionary<string, Func<Json>>
        {
            {"DateSorter",() => new DateSorterPage()},
            {"DistanceSorter", () => new DistanceSorterPage() },
            {"PPUSorter", () => new PricePerUnitSorterPage() },
            {"PriceSorter", () => new PriceSorterPage() },
            {"QuantitySorter", () => new QuantitySorterPage() },
            {"WeightedSorter", () => new WeightedSorterPage() }
        };

        void Handle(Input.SelectedSorter action)
        {
            var found = sorters.TryGetValue(action.Value, out Func<Json> function);
            if (found) Sorter = function.Invoke();
        }
    }
}

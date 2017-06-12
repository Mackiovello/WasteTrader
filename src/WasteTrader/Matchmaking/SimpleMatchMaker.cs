using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;
using WasteTrader.MathUtils;
using WasteTrader.Measurements;

namespace WasteTrader.Matchmaking
{
    class SimpleMatchMaker : RoughMatchMaker
    {

        protected bool DateFilter(DateTime time, IMatchParameters parameters)
        {
            if (time <= parameters.Youngest.ToUniversalTime())
                return false;
            else
                return (parameters.Oldest == null || time <= parameters.Oldest?.ToUniversalTime());
        }

        protected bool UnitTypeFilter(UnitType type, IMatchParameters parameters)
        {
            return (parameters.UnitType == 0 || type == parameters.UnitType);
        }

        protected bool QuantityFilter(long quantity, IMatchParameters parameters)
        {
            if (quantity < parameters.MinQuantity)
                return false;
            else
                return (parameters.MaxQuantity == 0 || quantity < parameters.MaxQuantity);
        }

        protected bool PricePerUnitFilter(long quantity, long price, IMatchParameters parameters)
        {
            return (parameters.PricePerUnitLimit == 0 || ((double)quantity) / price < parameters.PricePerUnitLimit);
        }

        protected bool DistanceFilter(ILocation location, IMatchParameters parameters)
        {
            if (parameters.SearchFrom == null)
                return true;

            double distance = GeographyMath.RoughEarthDistance(parameters.SearchFrom, location);

            if (distance > parameters.MinDistance)
                return false;
            else
                return (parameters.MaxDistance == 0 || distance < parameters.MaxDistance);

        }

        public override Waste[] Match(IMatchParameters parameters, IEnumerable<Waste> searchspace)
        {
            var filtered = searchspace.Where(waste =>
            {
                if (DateFilter(waste.EntryTime, parameters) == false)
                    return false;
                else if (UnitTypeFilter(waste.Unit, parameters) == false)
                    return false;

                IMeasurement measurement = waste.Measurement;

                if (QuantityFilter(measurement.Quantity, parameters) == false)
                    return false;
                else if (PricePerUnitFilter(measurement.Quantity, waste.Price, parameters) == false)
                    return false;
                else if (DistanceFilter(waste.Location, parameters) == false)
                    return false;
                else
                    return true;
            });

            Waste[] sorted = parameters.Sorter.Sort(filtered).Take(parameters.MaxMatches).ToArray();
            return sorted;
        }
    }
}

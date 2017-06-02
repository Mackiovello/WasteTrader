using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;
using WasteTrader.MathUtils;
using WasteTrader.Measurements;

namespace WasteTrader.Matchmaking
{
    class SimpleMatchMaker : RoughMatchMaker
    {
        public override ImmutableArray<IWaste> Match(IMatchParameters parameters, IImmutableSet<IWaste> searchspace)
        {
            var filtered = searchspace.AsParallel().Where(w =>
            {
                //Filter by date
                var univ = w.EntryTime.ToUniversalTime();
                if (univ <= parameters.Youngest.ToUniversalTime()) return false;
                else if (parameters.Oldest != null && univ >= parameters.Oldest.ToUniversalTime()) return false;

                //Filter by UnitType
                else if (parameters.UnitType != 0 && w.Unit != parameters.UnitType) return false;

                var measurement = MeasurementReader.Read(w).Item1;

                //Filter by Quantity
                if (measurement.Value < parameters.MinQuantity) return false;
                else if (parameters.MaxQuantity != 0 && measurement.Value > parameters.MaxQuantity) return false;

                //Filter by PricePerUnit
                if (parameters.PricePerUnitLimit != 0 && ((decimal)measurement.Value) / w.Price > parameters.PricePerUnitLimit) return false;

                //Filter by Distance
                double distance = GeographyMath.RoughEarthDistance(parameters.SearchFrom, w.Location);

                if (distance > parameters.MinDistance) return false;
                else if (parameters.MaxDistance != 0 && distance > parameters.MaxDistance) return false;

                return true;
            }).ToImmutableSortedSet();

            return parameters.Sorter.Sort(filtered);
        }
    }
}

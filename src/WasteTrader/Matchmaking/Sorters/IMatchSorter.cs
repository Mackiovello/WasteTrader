using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking.Sorters
{
    public interface IMatchSorter
    {
        Waste[] Sort(IEnumerable<Waste> waste);
    }
}

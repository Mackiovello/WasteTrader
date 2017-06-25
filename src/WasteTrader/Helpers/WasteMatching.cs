using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;

namespace WasteTrader.Helpers
{
    public class WasteMatching
    {
        private Waste WasteToMatch { get; set; }
        private IEnumerable<Waste> ToMatchAgainst { get; set; }

        public WasteMatching(Waste wasteToMatch, IEnumerable<Waste> toMatchAgainst)
        {
            this.WasteToMatch = wasteToMatch ?? throw new ArgumentNullException("wasteToMatch");
            this.ToMatchAgainst = toMatchAgainst ?? throw new ArgumentNullException("toMatchAgainst");
        }

        public IEnumerable<Waste> Match()
        {
            string titleToMatchAgainst = WasteToMatch.Title;
            List<Waste> matches = new List<Waste>();

            foreach (var waste in ToMatchAgainst)
            {
                if (waste.Title == titleToMatchAgainst)
                    matches.Add(waste);
            }

            return matches;
        }
    }
}

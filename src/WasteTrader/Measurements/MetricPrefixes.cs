using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public static class MetricPrefixes
    {
        public static ImmutableDictionary<int, string> Symbol = new Dictionary<int, String>
        {
            {-24,"y"},
            {-21, "z"},
            {-18,"a" },
            {-15, "f" },
            {-12, "p" },
            {-9, "n" },
            {-6,"μ" },
            {-3, "m" },
            {-2, "c" },
            {-1, "d" },
            {0, "" },
            {1, "da" },
            {2, "h" },
            {3, "k" },
            {6, "M" },
            {9, "G" },
            {12, "T" },
            {15, "P" },
            {18, "E" },
            {21, "Z" },
            {24, "Y" }
        }.ToImmutableDictionary();
    }
}

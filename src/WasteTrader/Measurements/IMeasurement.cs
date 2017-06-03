using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public interface IMeasurement<T> : IComparable, IEquatable<T>, IEqualityComparer<T>
    {
        /// <summary>
        /// All generally accepted units for a specific measurement.
        /// </summary>
        IImmutableDictionary<int, Unit> Symbols { get; }

        /// <summary>
        /// The value in the baseunit
        /// </summary>
        long Value { get; }

        /// <summary>
        /// The value in specified unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        long CalcValue(Unit unit);
        /// <summary>
        /// The power to use, i.e. 10^x
        /// </summary>
        int UnitMetricPrefixPower { get; set; }
        /// <summary>
        /// The value before 10^x
        /// </summary>
        long Quantity { get; set; }
        /// <summary>
        /// Raises, if possible and safe, the UnitMetricPrefixPower to a higher value while lowering Quantity.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        void ConvertOptimal();
    }
}

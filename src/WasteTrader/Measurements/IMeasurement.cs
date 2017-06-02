using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public interface IMeasurement<T> : IComparable, IEquatable<T>, IEqualityComparer<T>
    {
        IImmutableDictionary<sbyte,Unit> Symbols { get; }

        long Value { get; }

        long CalcValue(Unit unit);

        sbyte UnitMetricPrefixPower { get; set; }

        long Quantity { get; set; }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void ConvertOptimal();
    }
}

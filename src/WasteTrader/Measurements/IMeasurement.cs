using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    public interface IMeasurement<T> : IComparable, IEquatable<T>, IEqualityComparer<T>
    {
        IImmutableDictionary<sbyte,Unit> Symbols { get; }

        BigInteger Value { get; }

        BigInteger CalcValue(Unit unit);

        sbyte UnitMetricPrefixPower { get; set; }

        long Quantity { get; set; }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void Optimise();
    }
}

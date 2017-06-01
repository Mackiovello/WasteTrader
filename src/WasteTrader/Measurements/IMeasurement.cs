﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Immutable;

namespace WasteTrader.Measurements
{
    interface IMeasurement<T> : IComparable, IEquatable<T>, IEqualityComparer<T>, ICloneable where T : IMeasurement<T>
    {
        BigInteger Value { get; }

        sbyte UnitMetricPrefixPower { get; set; }

        long Quantity { get; set; }

        Tuple<string,sbyte> Unit(sbyte prefix);

        Tuple<string, sbyte> Unit(sbyte prefix, IImmutableDictionary<sbyte,string> dictionary);
    }
}

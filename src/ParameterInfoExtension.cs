using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Soenneker.Extensions.Spans.Readonly.ParameterInfos;

namespace Soenneker.Extensions.ParameterInfo;

/// <summary>
/// A collection of helpful ParameterInfo (Reflection) extension methods
/// </summary>
public static class ParameterInfoExtension
{
    /// <summary>
    /// Converts an array of <see cref="ParameterInfo"/> into an array of their corresponding <see cref="Type"/> objects.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type[] ToTypes(this System.Reflection.ParameterInfo[] parameterInfos) =>
        ((ReadOnlySpan<System.Reflection.ParameterInfo>)parameterInfos).ToTypes();
}
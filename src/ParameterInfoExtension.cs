using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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

    /// <summary>
    /// Converts a span of <see cref="ParameterInfo"/> into an array of their corresponding <see cref="Type"/> objects.
    /// </summary>
    [Pure]
    public static Type[] ToTypes(this ReadOnlySpan<System.Reflection.ParameterInfo> parameterInfos)
    {
        int length = parameterInfos.Length;

        if (length == 0)
            return [];

        if (length == 1)
            return [parameterInfos[0].ParameterType];

        var result = new Type[length];

        for (var i = 0; i < length; i++)
            result[i] = parameterInfos[i].ParameterType;

        return result;
    }
}
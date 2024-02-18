using System;

namespace Soenneker.Extensions.ParameterInfo;

/// <summary>
/// A collection of helpful ParameterInfo (Reflection) extension methods
/// </summary>
public static class ParameterInfoExtension
{
    /// <summary>
    /// Converts an array of ParameterInfo objects to an array of their corresponding parameter types.
    /// </summary>
    /// <param name="parameterInfos">The array of ParameterInfo objects.</param>
    /// <returns>An array of Type objects representing the parameter types.</returns>
    public static Type[] ToParametersTypes(this System.Reflection.ParameterInfo[] parameterInfos)
    {
        ReadOnlySpan<System.Reflection.ParameterInfo> span = parameterInfos;

        var typesArray = new Type[span.Length];

        for (var i = 0; i < span.Length; i++)
        {
            typesArray[i] = span[i].ParameterType;
        }

        return typesArray;
    }
}
using System;
using System.Buffers;

namespace Soenneker.Extensions.ParameterInfo;

/// <summary>
/// A collection of helpful ParameterInfo (Reflection) extension methods
/// </summary>
public static class ParameterInfoExtension
{
    /// <summary>
    /// Converts an array of <see cref="System.Reflection.ParameterInfo"/> objects into an array of their corresponding <see cref="Type"/> objects.
    /// </summary>
    /// <param name="parameterInfos">An array of <see cref="System.Reflection.ParameterInfo"/> objects to process.</param>
    /// <returns>
    /// An array of <see cref="Type"/> objects representing the parameter types of the provided <paramref name="parameterInfos"/>.
    /// </returns>
    /// <remarks>
    /// This method uses an <see cref="System.Buffers.ArrayPool{T}"/> to minimize memory allocations during processing.
    /// The array rented from the pool is returned immediately after use to ensure efficient memory management.
    /// </remarks>
    /// <example>
    /// The following example demonstrates how to use the <c>ToTypes</c> method:
    /// <code>
    /// var parameterInfos = typeof(SomeClass).GetMethod("SomeMethod")?.GetParameters();
    /// if (parameterInfos != null)
    /// {
    ///     Type[] parameterTypes = parameterInfos.ToTypes();
    ///     foreach (var type in parameterTypes)
    ///     {
    ///         Console.WriteLine(type.FullName);
    ///     }
    /// }
    /// </code>
    /// </example>
    public static Type[] ToTypes(this System.Reflection.ParameterInfo[] parameterInfos)
    {
        int length = parameterInfos.Length;

        if (length == 0)
            return [];

        // Rent an array from the pool
        ArrayPool<Type> arrayPool = ArrayPool<Type>.Shared;
        Type[] rentedArray = arrayPool.Rent(length);

        // Populate the rented array
        for (int i = 0; i < length; i++)
        {
            rentedArray[i] = parameterInfos[i].ParameterType;
        }

        // Create the final array to return
        var result = new Type[length];
        Array.Copy(rentedArray, result, length);

        // Return the rented array to the pool immediately
        arrayPool.Return(rentedArray, clearArray: true);

        return result;
    }
}
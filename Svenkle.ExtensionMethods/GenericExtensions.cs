using System;

namespace Svenkle.ExtensionMethods
{
    public static class GenericExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            return value.CompareTo(max) > 0 ? max : value;
        }
    }
}

using System;
using System.Collections.Generic;

namespace DroneStore.Web.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>() =>
            (T[])Enum.GetValues(typeof(T));
    }
}

using System;
using System.Collections.Generic;

namespace BattleshipGame.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                return true;
            }

            if (list is string)
            {
                return string.IsNullOrEmpty(list.ToString());
            }

            if (list is ICollection<T>)
            {
                return ((ICollection<T>)list).Count == 0;
            }


            return false;
        }
    }
}

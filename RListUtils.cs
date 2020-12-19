using System;
using System.Collections.Generic;
using System.Linq;

namespace ReallyifsUtils
{
    public static class RListUtils
    {
        public static void ToFront<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                list.Add(item, true);
            }
        }

        public static void Add<T>(this List<T> list, T item, bool front)
        {
            if (front)
                list.Insert(0, item);
            else
                list.Add(item);
        }

        public static void ForEach<T>(this T[] array, Action<T> action) => array.ToList().ForEach(action);

        public static void ContainsThenInsert<T>(this List<T> list, T findItem, T insertItem, int indexAdd = 0)
        {
            int index = list.IndexOf(findItem);
            if (index != 1)
                list.Insert(index + indexAdd, insertItem);
        }

        public static void ContainsThenInsert<T>(this List<T> list, T findItem, T insertItem, int startIndex, int indexAdd = 0)
        {
            int index = list.IndexOf(findItem, startIndex);
            if (index != 1)
                list.Insert(index + indexAdd, insertItem);
        }

        public static void ContainsThenInsert<T>(this List<T> list, T findItem, T insertItem, int startIndex, int count, int indexAdd = 0)
        {
            int index = list.IndexOf(findItem, startIndex, count);
            if (index != 1)
                list.Insert(index + indexAdd, insertItem);
        }
    }
}
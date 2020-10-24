using System;
using System.Reflection;

namespace ReallyifsUtils
{
    public static class RTypeUtils
    {
        public static T CreateDelegate<T>(this MethodInfo info, object target) where T : Delegate => (T)info.CreateDelegate(typeof(T), target);

        public static T CreateDelegate<T>(this MethodInfo info) where T : Delegate => (T)info.CreateDelegate(typeof(T));

        public static bool IsSubclassOf<T>(this Type type) => type.IsSubclassOf(typeof(T));
    }
}
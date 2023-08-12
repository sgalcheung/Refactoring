﻿using System;
using System.Linq;
using System.Reflection;

namespace refactoring2
{
    public static class AssignHelper
    {
        public static T CreateFromObjects<T>(params T[] sources)
            where T : new()
        {
            var ret = new T();
            MergeObjects(ret, sources);

            return ret;
        }

        private static void MergeObjects<T>(T target, params T[] sources)
        {
            Func<PropertyInfo, T, bool> predicate = (p, s) =>
            {
                if (p.GetValue(s)!.Equals(GetDefault(p.PropertyType)))
                {
                    return false;
                }

                return true;
            };

            MergeObjects(target, predicate, sources);
        }

        private static void MergeObjects<T>(T target, Func<PropertyInfo, T, bool> predicate, params T[] sources)
        {
            foreach (var propertyInfo in typeof(T).GetProperties().Where(prop => prop.CanRead && prop.CanWrite))
            {
                foreach (var source in sources)
                {
                    if (predicate(propertyInfo, source))
                    {
                        propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                    }
                }
            }
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
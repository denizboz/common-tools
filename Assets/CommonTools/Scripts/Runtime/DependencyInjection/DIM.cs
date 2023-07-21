using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonTools.Runtime.DependencyInjection
{
    /// <summary>
    /// Simple Dependency Injector for custom use, allowing multiple dependencies per type. In progress.
    /// </summary>
    public static class DIM
    {
        private static readonly Dictionary<Type, Dictionary<int, object>> dictionary =
            new Dictionary<Type, Dictionary<int, object>>();
        
        
        public static int Bind<T>(T dependency)
        {
            var type = typeof(T);

            if (!dictionary.ContainsKey(type))
                dictionary.Add(type, new Dictionary<int, object>());
            
            var subDictionary = dictionary[type];

            var hasKey = TryGetKey(subDictionary, dependency, out int key);

            if (hasKey)
            {
                Debug.LogWarning("Dependency already bound.");
                return key;
            }

            key = subDictionary.Count;
            
            subDictionary.Add(key, dependency);
            return key;
        }

        public static T Resolve<T>(int id)
        {
            var type = typeof(T);
            
            if (!dictionary.ContainsKey(type))
                throw new Exception($"No {type} reference in container.");

            var subDictionary = dictionary[type];

            if (!subDictionary.ContainsKey(id))
                throw new Exception($"No {type} reference with ID={id} in container.");

            return (T)subDictionary[id];
        }

        private static bool TryGetKey(Dictionary<int, object> dict, object value, out int key)
        {
            for (var i = 0; i < dict.Count; i++)
            {
                if (dict[i] == value)
                {
                    key = i;
                    return true;
                }
            }

            key = -1;
            return false;
        }
    }
}
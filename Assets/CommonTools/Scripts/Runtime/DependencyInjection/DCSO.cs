using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonTools.Runtime.DependencyInjection
{
    /*Simple Dependency Container Object for Multiple Injectors/Containers Case*/
    [CreateAssetMenu(fileName = "DCSO", menuName = "Dependency Injection/New DCSO")]
    public class DCSO : ScriptableObject
    {
        private readonly Dictionary<Type, object> m_systemsDictionary = new Dictionary<Type, object>(16);

        public void Bind<T>(T obj) // where T : AbstractSystemClass
        {
            var type = typeof(T);
            m_systemsDictionary[type] = obj;
        }

        public T Resolve<T>() // where T : AbstractSystemClass
        {
            var type = typeof(T);

            if (!m_systemsDictionary.ContainsKey(type))
                throw new Exception($"No {type} reference in container.");

            return (T)m_systemsDictionary[type];
        }
    }
}
using CommonTools.Runtime;
using UnityEngine;

namespace Demo
{
    public static class Tester
    {
        public static void Test()
        {
            var x = 15.CompareTo(15);
            
            Debug.Log(x);
        }

        private static int[] Sort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }

            return array;
        }
    }
}
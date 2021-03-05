using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace ArtemkaKun.Scripts.Helpers
{
    /// <summary>
    /// Class, that stores helper methods for arrays, lists and another IEnumerable.
    /// </summary>
    public static class EnumerableHelper
    {
        public static T GetRandomElement<T>(this IEnumerable<T> data)
        {
            var countOfElements = data.Count();
            
            if (countOfElements == 0)
            {
                throw new Exception("Cannot take a random element from empty list");
            }

            return data.ElementAt(Random.Range(0, countOfElements)); 
        }
    }
}
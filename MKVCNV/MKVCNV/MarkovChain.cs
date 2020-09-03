using System;
using System.Collections.Generic;

namespace MKVCNV
{
    class MarkovChain<T>
    {

        Dictionary<T, Dictionary<T, int>> Chain;
        Random rnd = new Random();
        public MarkovChain()
        {
            Chain = new Dictionary<T, Dictionary<T, int>>();
        }

        public void Add(T first, T second)
        {
            Dictionary<T, int> InnerMap;
            if (!Chain.ContainsKey(first))
            {
                InnerMap = new Dictionary<T, int>();
                InnerMap.Add(second, 0);
                Chain.Add(first, InnerMap);
            }
            else
            {
                InnerMap = Chain[first];
            }

            if (!InnerMap.ContainsKey(second))
            {
                InnerMap.Add(second, 0);
            }

            int weight = InnerMap[second];

            InnerMap.Remove(second);
            InnerMap.Add(second, weight + 1);
        }

        public T GetNext(T current)
        {
            Dictionary<T, int> weightedMap = Chain[current];

            int totalWeight = 0;

            foreach(KeyValuePair<T, int> weightEntry in weightedMap)
            {
                totalWeight += weightEntry.Value;
            }

            T next = default;
            foreach(KeyValuePair<T, int> weightEntry in weightedMap)
            {
                int chance = rnd.Next(0, totalWeight);
                if (chance<weightEntry.Value)
		        {
                    next = weightEntry.Key;
                    break;
                }

                totalWeight -= weightEntry.Value;

            }
	        return next;
        }
}
}

using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class AllLootStrategy : ILootGenerationStrategy
    {
        public Dictionary<GameObject, Subject> FilterLoot(Dictionary<GameObject, Subject> source)
        {
            var result = new Dictionary<GameObject, Subject>();
            foreach (var item in source)
            {
                result.Add(item.Key, item.Value);
            }
            return result;
        }
    }
}

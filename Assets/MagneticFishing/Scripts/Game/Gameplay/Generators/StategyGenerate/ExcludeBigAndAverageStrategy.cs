using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class ExcludeBigAndAverageStrategy : ILootGenerationStrategy
    {
        public Dictionary<GameObject, Subject> FilterLoot(Dictionary<GameObject, Subject> source)
        {
            var result = new Dictionary<GameObject, Subject>();
            foreach (var item in source)
            {
                if (item.Value.description.descriptionOfItem.Size != SizeProp.Big &&
                    item.Value.description.descriptionOfItem.Size != SizeProp.Average)
                    result.Add(item.Key, item.Value);
            }
            return result;
        }
    }
}

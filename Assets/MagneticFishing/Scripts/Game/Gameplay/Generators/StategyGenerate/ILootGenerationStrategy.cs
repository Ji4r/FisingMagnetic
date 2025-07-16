using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public interface ILootGenerationStrategy
    {
        public Dictionary<GameObject, Subject> FilterLoot(Dictionary<GameObject, Subject> source);
    }
}

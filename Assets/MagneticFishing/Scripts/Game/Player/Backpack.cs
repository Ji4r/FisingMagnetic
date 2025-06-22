using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class Backpack : MonoBehaviour
    {
        public int capacityBackpack;
        public List<Subject> listItems;

        public void Init(int capacityBackpack)
        {
            this.capacityBackpack = capacityBackpack;
            listItems = new List<Subject>(this.capacityBackpack);
        }

        public void AddItamInBackpack(Subject item)
        {
            if (listItems.Count < capacityBackpack)
            {
                listItems.Add(item);
            }
        }
    }
}

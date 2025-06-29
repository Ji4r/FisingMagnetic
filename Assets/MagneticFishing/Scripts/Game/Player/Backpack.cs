using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class Backpack : MonoBehaviour
    {
        public int capacityBackpack = 30;
        public List<Subject> listItems;

        public void Init(int capacityBackpack)
        {
            this.capacityBackpack = capacityBackpack;
            listItems = new List<Subject>(this.capacityBackpack);
            EventBusGame.AddItemInInventory?.Invoke(listItems);
        }

        public void AddItamInBackpack(Subject item)
        {
            if (listItems.Count < capacityBackpack)
            {
                listItems.Add(item);
                EventBusGame.AddItemInInventory?.Invoke(listItems);
            }
        }
    }
}

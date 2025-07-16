using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class Backpack : MonoBehaviour
    {
        public int capacityBackpack = 30;
        public List<SubjectDescription> listItems;

        public void Init(int capacityBackpack)
        {
            this.capacityBackpack = capacityBackpack;
            listItems = new List<SubjectDescription>(this.capacityBackpack);
            EventBusGame.AddItemInInventory?.Invoke(listItems);
        }

        public void AddItemInBackpack(SubjectDescription item)
        {
            if (listItems.Count < capacityBackpack)
            {
                SubjectDescription newItem = (SubjectDescription)item.Clone();

                listItems.Add(newItem);
                SaveSystemsDataGame.instans.dataGame.AddItem(item);
                EventBusGame.AddItemInInventory?.Invoke(listItems);   
            }
        }

        public void DeleteItem(SubjectDescription item)
        {
            if (item != null)
            {
                listItems.Remove(item);
                SaveSystemsDataGame.instans.dataGame.RemoveItem(item);
                EventBusGame.ChangeUiCountSlots?.Invoke(listItems.Count, capacityBackpack);
            }
        }
    }
}

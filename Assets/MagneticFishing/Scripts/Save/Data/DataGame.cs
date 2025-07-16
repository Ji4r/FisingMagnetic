using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MagneticFishing
{
    [System.Serializable]    
    public class DataGame : IService
    {
        public int capacitybackpack;
        public int money = 99;
        public int countLoot = 20;
        public List<SubjectDescription> loot = new List<SubjectDescription>();

        public void GetMoney(int money)
        {

        }

        public void AddItem(SubjectDescription item)
        {
            if (loot.Count < capacitybackpack && item != null)
            {
                loot.Add(item.Clone());
                SaveSystemsDataGame.instans.Save();
            }
        }

        public void RemoveItem(SubjectDescription item)
        {
            if (item != null && loot.Remove(item))
            {
                SaveSystemsDataGame.instans.Save();
            }
        }
    }
}

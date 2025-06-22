using UnityEngine;

namespace MagneticFishing
{
    public class ModelMenu
    {
        public int money { get; private set; }
        public int countLoot { get; private set; }

        public void UpdateFromData(DataGame data)
        {
            money = data.money;
            countLoot = data.countLoot;
        }
    }
}

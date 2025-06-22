using UnityEngine;

namespace MagneticFishing
{
    [System.Serializable]    
    public class DataGame : IService
    {
        public int money = 99;
        public int countLoot = 20;

        public DataGame(int _money, int _slots)
        {
            money = _money;
            countLoot = _slots;
        }
    }
}

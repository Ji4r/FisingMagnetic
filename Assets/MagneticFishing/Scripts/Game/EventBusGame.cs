using System;
using System.Collections.Generic;

namespace MagneticFishing
{
    public static class EventBusGame 
    {
        public static Action<bool> AttractedAMagnet;
        public static Action<int, int> ChangeUiCountSlots;
        public static Action ClouseLootWindow;
        public static Action<float, float> ChangeFieldsEnergy;
        public static Action<List<Subject>> AddItemInInventory;
    }
}

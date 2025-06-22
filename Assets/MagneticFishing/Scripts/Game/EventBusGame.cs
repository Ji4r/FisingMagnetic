using System;

namespace MagneticFishing
{
    public static class EventBusGame 
    {
        public static Action<bool> AttractedAMagnet;
        public static Action<int, int> ChangeUiCountSlots;
    }
}

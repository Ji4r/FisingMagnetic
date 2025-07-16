using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public static class EventBusGame 
    {
        public static Action<bool> AttractedAMagnet;
        public static Action<int, int> ChangeUiCountSlots;
        public static Action ClouseLootWindow;
        public static Action<float, float> ChangeFieldsEnergy;
        public static Action<List<SubjectDescription>> AddItemInInventory;

        public static Action<Vector3> StartCasting;
        public static Action<Vector3> EndCasting;
        public static Action EndAttraction;

        public static Action AnimationOfAttraction;
    }
}

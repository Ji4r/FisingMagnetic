using UnityEngine;
using Zenject;

namespace MagneticFishing
{
    public class ScreenLoot : MonoBehaviour
    {
        [Header("—ылки на скрипты")]
        [SerializeField] private ObjectAttractor objectAttractor;
        [SerializeField] private FishingMagnetic fishingMagnetic;

        [Header("—сылки на компоненты")]
        [SerializeField] private Transform panelLoot;


        public void SetActivePanel()
        {
            fishingMagnetic.enabled = false;
            objectAttractor.enabled = false;

            panelLoot.gameObject.SetActive(true);
        }


        public void SetDisactivePanel()
        {
            fishingMagnetic.enabled = true;

            panelLoot.gameObject.SetActive(false);
        }
    }
}

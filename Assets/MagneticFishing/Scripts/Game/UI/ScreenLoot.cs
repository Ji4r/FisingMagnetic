using UnityEngine;
using Zenject;

namespace MagneticFishing
{
    public class ScreenLoot : MonoBehaviour
    {
        [Header("—ылки на скрипты")]
        [SerializeField] private ObjectAttractor objectAttractor;
        [SerializeField] private FishingMagnetic fishingMagnetic;
        [SerializeField] private HandlerPanelAnims panelAnims;

        [Header("—сылки на компоненты")]
        [SerializeField] private Transform panelLoot;

        private void OnEnable()
        {
            EventBusGame.ClouseLootWindow += SetDisactivePanel;
        }

        private void OnDisable()
        {
            EventBusGame.ClouseLootWindow -= SetDisactivePanel;
        }

        public void SetActivePanel()
        {
            fishingMagnetic.enabled = false;
            objectAttractor.enabled = false;
            panelAnims.TogglePanel(true);
        }


        public void SetDisactivePanel()
        {
            fishingMagnetic.enabled = true;
            panelAnims.TogglePanel(false);
        }
    }
}

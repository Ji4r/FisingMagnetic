using UnityEngine;
using UnityEngine.EventSystems;

namespace MagneticFishing
{
    public class MagneticCaster : MonoBehaviour, IPointerClickHandler
    {
        private Camera cameraMain;
        private bool isMagneticAbandoned;

        private void Awake()
        {
            cameraMain = GameObject.FindAnyObjectByType<Camera>();
            isMagneticAbandoned = false;
        }

        private void OnEnable()
        {
            EventBusGame.AttractedAMagnet += SetChangeMagneticAbandoned;
        }

        private void OnDisable()
        {
            EventBusGame.AttractedAMagnet -= SetChangeMagneticAbandoned;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isMagneticAbandoned)
            { return; }
            isMagneticAbandoned = true;

            var pointClick = Input.mousePosition;
            pointClick.z = 0;

            EventBusGame.StartCasting?.Invoke(pointClick);
        }

        private void SetChangeMagneticAbandoned(bool state)
        {
            isMagneticAbandoned = state;
        }
    }
}

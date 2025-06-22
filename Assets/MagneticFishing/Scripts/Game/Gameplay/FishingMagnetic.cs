using UnityEngine;
using UnityEngine.EventSystems;

namespace MagneticFishing
{
    public class FishingMagnetic : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject gameObj;
        [SerializeField] private Transform parentForMagnetic;

        private LootGenerator lootGenerator;
        private ObjectAttractor objectAttractor;
        private Camera cameraMain;
        private bool isMagneticAbandoned;
        private GameObject gameObjMagnited;

        private void OnEnable()
        {
            EventBusGame.AttractedAMagnet += SetChangeMagneticAbandoned;
        }

        private void OnDisable()
        {
            EventBusGame.AttractedAMagnet -= SetChangeMagneticAbandoned;
        }

        private void Awake()
        {
            objectAttractor = GameObject.FindFirstObjectByType<ObjectAttractor>();
            lootGenerator = GameObject.FindFirstObjectByType<LootGenerator>();
            cameraMain = GameObject.FindAnyObjectByType<Camera>();

            isMagneticAbandoned = false;
            gameObjMagnited = Instantiate(gameObj, Vector3.zero, Quaternion.identity);
            gameObjMagnited.SetActive(false);
            gameObjMagnited.transform.SetParent(parentForMagnetic, true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Клик по UI через EventSystem!");
            if (isMagneticAbandoned)
            { return; }
            isMagneticAbandoned = true;

            var pointClick = Input.mousePosition;
            pointClick.z = 0;

            gameObjMagnited.transform.position = pointClick;
            gameObjMagnited.SetActive(true);

            objectAttractor.ottudovaPull = gameObjMagnited.transform;
            objectAttractor.enabled = true;
            lootGenerator.GenarateLoot();
        }


        private void SetChangeMagneticAbandoned(bool state)
        {
            isMagneticAbandoned = state;
        }
    }
}

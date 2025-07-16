using UnityEngine;

namespace MagneticFishing
{
    public class MagneticController : MonoBehaviour
    {
        [SerializeField, Tooltip("Префаб")] private GameObject objectMagnetic;
        [SerializeField] private Transform parentForMagnetic;
        [SerializeField] private GameObject gameObjMagnited;

        private LootGenerator lootGenerator;
        private ObjectAttractor objectAttractor;

        private void Awake()
        {
            objectAttractor = GameObject.FindFirstObjectByType<ObjectAttractor>();
            lootGenerator = GameObject.FindFirstObjectByType<LootGenerator>();

            gameObjMagnited.transform.SetParent(parentForMagnetic, true);
        }

        public void EndCastingRope(Vector3 pointClick)
        {
            gameObjMagnited.transform.position = pointClick;
            gameObjMagnited.SetActive(true);

            objectAttractor.ottudovaPull = gameObjMagnited.transform;
            objectAttractor.enabled = true;
            lootGenerator.GenarateLoot();
        }
    }
}

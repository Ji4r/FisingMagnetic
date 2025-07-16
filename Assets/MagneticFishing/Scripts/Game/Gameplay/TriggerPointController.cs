using UnityEngine;

namespace MagneticFishing
{
    public class TriggerPointController : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        private void OnEnable()
        {
            EventBusGame.StartCasting += SetPointPosition;
        }

        private void OnDisable()
        {
            EventBusGame.StartCasting -= SetPointPosition;
        }

        private void SetPointPosition(Vector3 pos)
        {
            rectTransform.position = new Vector3(pos.x, rectTransform.position.y, rectTransform.position.z);
        }
    }
}

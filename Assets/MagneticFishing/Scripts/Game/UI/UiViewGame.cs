using TMPro;
using UnityEngine;

namespace MagneticFishing
{
    public class UiViewGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textDistance;
        [SerializeField] private Transform panelLoot;
        [SerializeField] private RectTransform[] spawnPositionLoot;
        [SerializeField] private TextMeshProUGUI textSlots;

        private void OnEnable()
        {
            EventBusGame.ChangeUiCountSlots += ChangeCountSlotsText;
        }

        private void OnDisable()
        {
            EventBusGame.ChangeUiCountSlots -= ChangeCountSlotsText;
        }

        public void SetDistanceText(Vector3 positionObjectAttractor, Vector3 ottudovaPull)
        {
            float distance = positionObjectAttractor.y - ottudovaPull.y;
            distance = Mathf.Abs(distance);
            textDistance.text = distance.ToString("F2");
        }
        public void SetDistanceTextZero()
        {
            textDistance.text = 0.ToString();
        }


        public RectTransform[] GetSpawnPositionLoot()
        {
            return spawnPositionLoot;
        }

        public Transform GetPaneLoot()
        {
            return panelLoot;
        }


        public void ChangeCountSlotsText(int countTakeItem, int countSlots)
        {
            textSlots.text = $"{countTakeItem}/{countSlots}";
        }
    }
}

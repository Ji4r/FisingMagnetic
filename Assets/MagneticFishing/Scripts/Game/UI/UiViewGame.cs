using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class UiViewGame : MonoBehaviour
    {
        [Header("Настройки дистанции")]
        [SerializeField] private TextMeshProUGUI textDistance;
        [Header("Настройки спавна предметов")]
        [SerializeField] private Transform panelLoot;
        [SerializeField] private RectTransform[] spawnPositionLoot;
        [SerializeField] private TextMeshProUGUI textSlots;
        [Header("Настройки энергии")]
        [SerializeField] private Image energyField;
        [Header("Настройки слота")]
        [SerializeField] private GameObject prefabSlot;
        [SerializeField] private RectTransform parentSlot;
        [SerializeField] private ManagmentSlotsFromProp managmentSlotsFromProp;
        private HashSet<int> gameObjectsId;

        private void Start()
        {
            gameObjectsId = new HashSet<int>();
        }

        private void OnEnable()
        {
            EventBusGame.ChangeUiCountSlots += ChangeCountSlotsText;
            EventBusGame.ChangeFieldsEnergy += ChangeFieldsEnergy;
            EventBusGame.AddItemInInventory += ChangeWindowBackpack;
        }

        private void OnDisable()
        {
            EventBusGame.ChangeUiCountSlots -= ChangeCountSlotsText;
            EventBusGame.ChangeFieldsEnergy -= ChangeFieldsEnergy;
            EventBusGame.AddItemInInventory -= ChangeWindowBackpack;
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


        private void ChangeCountSlotsText(int countTakeItem, int countSlots)
        {
            textSlots.text = $"{countTakeItem}/{countSlots}";
        }

        private void ChangeFieldsEnergy(float currencyEnergy, float maxEnergy)
        {
            energyField.fillAmount = currencyEnergy / maxEnergy;
        }

        private void ChangeWindowBackpack(List<SubjectDescription> subjects)
        {
           foreach (SubjectDescription subject in subjects)
           {
                if (gameObjectsId.Contains(subject.Id))
                    continue;
                if (!managmentSlotsFromProp.GetFreeSlots().TryGetComponent<UiSlot>(out var card))
                    continue;

                gameObjectsId.Add(subject.Id);
                card.transform.SetParent(parentSlot);
                Debug.Log(subject + " subject");
                card.subject = subject;
                card.cost.text = subject.descriptionOfItem.Price.ToString();
                card.sprite.sprite = subject.descriptionOfItem.SpriteSubject;
           }
        }
    }
}

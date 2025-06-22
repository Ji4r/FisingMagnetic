using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class TakeSubject : MonoBehaviour, IPointerClickHandler
    {
        [Header("—сылки на кнопки")]
        [SerializeField] private Button buttonDrop;
        [SerializeField] private Button buttonTake;

        [Header("—сылки на скрипты")]
        [SerializeField] private LootGenerator lootGenerator;
        [SerializeField] private Backpack backpack;

        [SerializeField] private RectTransform panelTake;
        [SerializeField] private TextMeshProUGUI nameSubject;
        [SerializeField] private TextMeshProUGUI descriptionSubject;
        [SerializeField] private Image spriteSubject;

        private Subject selectedItem;

        private void OnEnable()
        {
            buttonDrop.onClick.AddListener(ButtonDropItem);
            buttonTake.onClick.AddListener(ButtonTakeItem);
        }

        private void OnDisable()
        {
            buttonDrop.onClick.RemoveListener(ButtonDropItem);
            buttonTake.onClick.RemoveListener(ButtonTakeItem);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

                if (clickedObject.TryGetComponent<Subject>(out var subject))
                {
                    selectedItem = subject;
                    nameSubject.text = subject.descriptionOfItem.Name;
                    descriptionSubject.text = subject.descriptionOfItem.Description;
                    spriteSubject.sprite = subject.descriptionOfItem.SpriteSubject;
                    panelTake.gameObject.SetActive(true);
                }
            }
        }

        public void ButtonDropItem()
        {
            if (selectedItem != null)
                Destroy(selectedItem.gameObject);
            panelTake.gameObject.SetActive(false);
        }

        public void ButtonTakeItem()
        {
            panelTake.gameObject.SetActive(false);
            if (selectedItem == null)
            { return; }

            backpack.AddItamInBackpack(selectedItem);
            EventBusGame.ChangeUiCountSlots?.Invoke(backpack.listItems.Count, backpack.capacityBackpack);
            Destroy(selectedItem.gameObject);
        }
    }
}

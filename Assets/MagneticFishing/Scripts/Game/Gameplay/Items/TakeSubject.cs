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
        [SerializeField, Tooltip("—сылка на скрипт с анимаци€ми панели")] private HandlerPanelAnims panelTake;

        [SerializeField] private TextMeshProUGUI nameSubject;
        [SerializeField] private TextMeshProUGUI descriptionSubject;
        [SerializeField] private Image spriteSubject;

        private Subject selectedItem;

        private void Start()
        {
            EventBusGame.ChangeUiCountSlots?.Invoke(backpack.listItems.Count, backpack.capacityBackpack);
        }
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
                    nameSubject.text = subject.description.descriptionOfItem.Name;
                    descriptionSubject.text = subject.description.descriptionOfItem.Description;
                    spriteSubject.sprite = subject.description.descriptionOfItem.SpriteSubject;
                    panelTake.TogglePanel(true);
                }
            }
        }

        public void ButtonDropItem()
        {
            if (selectedItem != null)
                Destroy(selectedItem.gameObject);
            panelTake.TogglePanel(false);
            GeneratorIdProp.ReleaseId(selectedItem.description.Id);
            DeleteProp();
        }

        public void ButtonTakeItem()
        {
            panelTake.TogglePanel(false);
            if (selectedItem == null)
            { return; }

            backpack.AddItemInBackpack(selectedItem.description);
            EventBusGame.ChangeUiCountSlots?.Invoke(backpack.listItems.Count, backpack.capacityBackpack);
            selectedItem.gameObject.SetActive(false);
            DeleteProp();
        }

        public void DeleteProp()
        {
            if (!lootGenerator.DeleteItemFromArray())
            {
                EventBusGame.ClouseLootWindow?.Invoke();
            }
        }
    }
}

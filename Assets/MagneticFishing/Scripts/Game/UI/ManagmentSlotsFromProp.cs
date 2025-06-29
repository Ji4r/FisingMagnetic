using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class ManagmentSlotsFromProp : MonoBehaviour
    {
        [SerializeField] private Backpack backpack;
        [SerializeField] private List<GameObject> slotsProp;
        [SerializeField] private RectTransform parentSlot;
        [SerializeField] private GameObject prefabSlots;

        private void Awake()
        {
            CreateSlots();
        }

        public void CreateSlots()
        {
            var numberOfMissingSlots = backpack.capacityBackpack - slotsProp.Count;

            for (int i = 0; i < numberOfMissingSlots; i++)
            {
                GameObject newSlots = Instantiate(prefabSlots);
                newSlots.TryGetComponent<UiSlot>(out var card);

                card.transform.SetParent(parentSlot);
                card.transform.localScale = card.scale;
                slotsProp.Add(newSlots);
            }

            for (int i = 0; i < slotsProp.Count; i++)
            {
                slotsProp[i].SetActive(false);
            }
        }

        public GameObject GetFreeSlots()
        {
            for (int i = 0; i < slotsProp.Count; i++)
            {
                if (!slotsProp[i].activeSelf)
                {
                    slotsProp[i].SetActive(true);
                    return slotsProp[i];
                }
            }
            return null;
        }
    }
}

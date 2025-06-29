using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class UiSlot : MonoBehaviour
    {
        public Button buttonDrop;
        public TextMeshProUGUI cost;
        public Image sprite;
        public Vector3 scale;

        private void Awake()
        {
            scale = transform.localScale;
            transform.localScale = scale;
        }

        private void OnEnable()
        {
            buttonDrop.onClick.AddListener(DropItems);
        }

        private void OnDisable()
        {
           buttonDrop.onClick.RemoveListener(DropItems);
        }

        private void DropItems()
        {
            gameObject.SetActive(false);
        }
    }
}

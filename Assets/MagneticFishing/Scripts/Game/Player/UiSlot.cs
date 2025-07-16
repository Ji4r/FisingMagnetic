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
        public SubjectDescription subject;

        private Backpack backpack;

        private void Awake()
        {
            scale = transform.localScale;
            transform.localScale = scale;
            backpack = GameObject.FindFirstObjectByType<Backpack>();
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
            Debug.Log(subject);
            gameObject.SetActive(false);
            backpack.DeleteItem(subject);
        }
    }
}

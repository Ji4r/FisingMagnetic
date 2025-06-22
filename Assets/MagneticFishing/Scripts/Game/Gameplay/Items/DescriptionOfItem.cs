using UnityEngine;
using UnityEngine.UI;

namespace MagneticFishing
{
    [CreateAssetMenu(fileName = "Item", menuName = "Subject/Create new Item")]
    public class DescriptionOfItem : ScriptableObject
    {

        [SerializeField] private string name;
        [SerializeField, TextArea(2, 7)] private string description;
        [SerializeField, Tooltip("Вес объекта")] private float weightObject;
        [SerializeField, Tooltip("Стоимость объекта")] private float price;
        [SerializeField] private Sprite sprite;
        [SerializeField] private GameObject prefab;

        public string Name { get { return name; }}
        public string Description { get { return description; } }
        public float WeightObject { get { return weightObject; } }
        public float Price { get { return price; } }
        public Sprite SpriteSubject { get { return sprite; } }
        public GameObject Prefab { get {  return prefab; } }
    }
}

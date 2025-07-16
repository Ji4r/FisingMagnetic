using UnityEngine;

namespace MagneticFishing
{
    public enum SizeProp
    {
        Small, MoreThanSmall, Average, Big
    }

    [CreateAssetMenu(fileName = "Item", menuName = "Subject/Create new Item")]
    public class DescriptionOfItem : ScriptableObject
    {

        [SerializeField] private string name;
        [SerializeField, TextArea(2, 7)] private string description;
        [SerializeField, Tooltip("Вес объекта")] private float weightObject;
        [SerializeField, Tooltip("Стоимость объекта")] private float price;
        [SerializeField] private Sprite sprite;
        [SerializeField] private SizeProp size;
        [SerializeField] private GameObject prefab;

        public string Name { get { return name; }}
        public string Description { get { return description; } }
        public float WeightObject { get { return weightObject; } }
        public float Price { get { return price; } }
        public Sprite SpriteSubject { get { return sprite; } }
        public GameObject Prefab { get {  return prefab; } }
        public SizeProp Size { get { return size; } }

        public DescriptionOfItem Clone()
        {
            // Создаем новый экземпляр ScriptableObject
            DescriptionOfItem clone = CreateInstance<DescriptionOfItem>();

            // Копируем все значимые поля
            clone.name = this.name;
            clone.description = this.description;
            clone.weightObject = this.weightObject;
            clone.price = this.price;

            // Копируем ссылки на Unity-ассеты (без создания копий)
            clone.sprite = this.sprite;
            clone.prefab = this.prefab;
            clone.size = this.size;

            return clone;
        }
    }
}

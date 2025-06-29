using UnityEngine;

namespace MagneticFishing
{
    public class Subject : MonoBehaviour
    {
        public DescriptionOfItem descriptionOfItem;
        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

namespace MagneticFishing
{
    [System.Serializable]
    public class SubjectDescription
    {
        public DescriptionOfItem descriptionOfItem;
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }

        public SubjectDescription Clone()
        {
            return new SubjectDescription
            {
                descriptionOfItem = this.descriptionOfItem?.Clone(), // Если DescriptionOfItem тоже копируемый
                id = this.id
            };
        }

        
    }
}

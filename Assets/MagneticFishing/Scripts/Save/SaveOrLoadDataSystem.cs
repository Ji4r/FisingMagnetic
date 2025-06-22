using UnityEngine;

namespace MagneticFishing
{
    public class SaveOrLoadDataSystem : MonoBehaviour
    {
        public const string KEY = "MF_";
        private IStorageService storageService;


        private void Awake()
        {
            storageService = new SaveService();
        }

        public void Save(object data)
        {
            string key = KEY + data.GetType();
            Debug.Log("Процес сохранения");
            storageService.Save(key, data);
        }

        public T Load<T>()
        {
            string key = KEY + typeof(T);
            Debug.Log("Процес загрузки");

            return storageService.Load<T>(key);
        }

        public bool ChekingFile(object data)
        {
            string key = KEY + data.GetType();
            return storageService.CheckingFile(key);
        }
    }
}

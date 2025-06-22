using System;
using System.IO;
using UnityEngine;

namespace MagneticFishing
{
    public class SaveService : IStorageService
    {

        public T Load<T>(string key)
        {
            string path = BuildPath(key);
            Debug.Log(path);

            if (!File.Exists(path))
            {
                throw new Exception("Error file не найден");
            }

            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                var data = JsonUtility.FromJson<T>(json);
                Debug.Log(data);
                return data;
            }
        }

        public void Save(string key, object data, Action<bool> callback = null)
        {
            string path = BuildPath(key);
            Debug.Log(path);
            string json = JsonUtility.ToJson(data);

            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
                Debug.Log(json);
            }

            callback?.Invoke(true);
        }

        public bool CheckingFile(string key)
        {
            string path = BuildPath(key);

            return File.Exists(path);
        }
        

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}

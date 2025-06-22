using System;

namespace MagneticFishing
{
    public interface IStorageService
    {
        public void Save(string key, object data, Action<bool> callback = null);
        public T Load<T>(string key);
        public bool CheckingFile(string key);
    }
}

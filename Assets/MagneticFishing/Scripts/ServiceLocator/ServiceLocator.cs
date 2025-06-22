using System;
using System.Collections.Generic;

namespace MagneticFishing
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> itemsMap { get; }

        public ServiceLocator() 
        {
            itemsMap = new Dictionary<Type, T>();
        }

        public TP Register<TP>(TP newService) where TP : T
        {
            var type = newService.GetType();

            if (itemsMap.ContainsKey(type))
            {
                throw new Exception($"Уже есть такой сервис {type}");
            }

            itemsMap[type] = newService;

            return newService;
        }

        public void Unregister<TP>(TP service) where TP : T
        {
            var type = service.GetType();

            if (itemsMap.ContainsKey(type))
            {
                itemsMap.Remove(type);
            }
        }

        public TP Get<TP>() where TP : T
        {
            var type = typeof(TP);

            if (!itemsMap.ContainsKey(type))
            {
                throw new Exception($"Non service {type}");
            }

            return (TP)itemsMap[type];
        }

        public void RewriteRegistry<TP>(TP newData) where TP : T
        {
            var type = typeof(TP);

            if (itemsMap.ContainsKey(type))
            {
                if (itemsMap[type] is IDisposable disposable)
                {
                    disposable.Dispose();
                }

                itemsMap[type] = newData;
            }
            else
            {
                throw new Exception($"Сервис {type.Name} не найден для перезаписи");
            }
        }
    }
}

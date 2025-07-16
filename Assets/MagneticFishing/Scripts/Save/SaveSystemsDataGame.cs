using UnityEngine;

namespace MagneticFishing
{
    public class SaveSystemsDataGame : MonoBehaviour
    {
        public static SaveSystemsDataGame instans;

        public DataGame dataGame;
        private SaveOrLoadDataSystem saveOrLoadDataSystem;
        private ServiceSave serviceSave;
        private IServiceLocator<IService> service;

        private void Awake()
        {
            if (instans == null)
                instans = this;
            else
                Destroy(this);

            service = serviceSave.Locator;
        }

        public void Save()
        {
            if (!saveOrLoadDataSystem.ChekingFile(service.Get<DataSettings>()))
                saveOrLoadDataSystem.Save(service.Get<DataSettings>());
            else
            {
                DataSettings settingsData = saveOrLoadDataSystem.Load<DataSettings>();
                service.RewriteRegistry<DataSettings>(settingsData);
            }
            if (!saveOrLoadDataSystem.ChekingFile(service.Get<DataGame>()))
                saveOrLoadDataSystem.Save(service.Get<DataGame>());
            else
            {
                DataGame gameData = saveOrLoadDataSystem.Load<DataGame>();
                service.RewriteRegistry<DataGame>(gameData);
            }

            Debug.Log("Произошло сохранение!!!!");
        }

        public object Load()
        {
            return new object();
        }
    }
}

using UnityEngine;

namespace MagneticFishing
{
    public class ServiceSave : MonoBehaviour
    {
        private IServiceLocator<IService> _locator;
        public IServiceLocator<IService> Locator => _locator;
        private void Awake()
        {
            _locator = new ServiceLocator<IService>();

            var saveSystem = new SaveOrLoadDataSystem();

            DataSettings dataSettings;
            if (saveSystem.ChekingFile(typeof(DataSettings)))
            {
                dataSettings = saveSystem.Load<DataSettings>();
            }
            else
            {
                dataSettings = new DataSettings();
                saveSystem.Save(dataSettings);
            }

            DataGame dataGame;
            if (saveSystem.ChekingFile(typeof(DataGame)))
            {
                dataGame = saveSystem.Load<DataGame>();
            }
            else
            {
                dataGame = new DataGame();
                saveSystem.Save(dataGame);
            }

            // 4. Регистрируем сервисы
            _locator.Register(dataSettings);
            _locator.Register(dataGame);
        }

        private void OnDisable()
        {
        }
    }
}

using Unity.Collections;
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

            var dataSetting = new DataSettings();
            var dataGame = new DataGame(10,45);

            _locator.Register(dataSetting);
            _locator.Register(dataGame);
        }

        private void OnDisable()
        {
            //locator.Unregister<DataGame>();
            //locator.Unregister(new DataSettings());
        }
    }
}

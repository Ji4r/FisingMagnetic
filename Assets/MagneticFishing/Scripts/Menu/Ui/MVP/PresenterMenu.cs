using UnityEngine;

namespace MagneticFishing
{
    public class PresenterMenu
    {
        private readonly ModelMenu model;
        private readonly UIViewMenu view;
        private readonly IServiceLocator<IService> service;

        public PresenterMenu(ModelMenu model, UIViewMenu view, IServiceLocator<IService> service)
        {
            this.model = model;
            this.view = view;
            this.service = service;

            Initialize();
        }

        private void Initialize()
        {
            DataGame data = service.Get<DataGame>();
            model.UpdateFromData(data);
            view.UpdateUI(model.money, model.countLoot);
        }

        public void Update()
        {
            DataGame data = service.Get<DataGame>();
            model.UpdateFromData(data);
            view.UpdateUI(model.money, model.countLoot);
        }
    }
}

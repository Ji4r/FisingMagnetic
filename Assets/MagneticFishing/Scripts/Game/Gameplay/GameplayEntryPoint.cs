using System;
using UnityEngine;

namespace MagneticFishing
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UiGameplayRootBinder sceneUiRootPrefab;
        [SerializeField] private Camera mainCamera;

        public event Action GoToMainMenuSceneRequested;

        private SaveOrLoadDataSystem dataSystem;

        public void Run(ScreenLoadView uiRoot)
        {
            var uiScene = Instantiate(sceneUiRootPrefab);
            uiRoot.AttachSceneUi(uiScene.gameObject);

            uiScene.HandleGoToMenuButtonClick();

            uiScene.GoToMainMenuBuutonClicked += () =>
            {
                GoToMainMenuSceneRequested?.Invoke();
            };

            dataSystem = GameObject.FindFirstObjectByType<SaveOrLoadDataSystem>();
            dataSystem.Load<DataGame>();

            Backpack backpack = GameObject.FindFirstObjectByType<Backpack>();
            backpack.Init(20); // load data
        }
    }
}

using System;
using UnityEngine;

namespace MagneticFishing
{
    public class EntryPointMenu : MonoBehaviour
    {
        [SerializeField] private UiMainMenuRootBinder sceneUiRootPrefab;

        public event Action GoToGameplaySceneRequested;

        public void Run(ScreenLoadView uiRoot)
        {
            var uiScene = Instantiate(sceneUiRootPrefab);
            uiRoot.AttachSceneUi(uiScene.gameObject);

            uiScene.HandleGoToGameplayButtonClick();

            uiScene.GoToGameplayBuutonClicked += () =>
            {
                GoToGameplaySceneRequested?.Invoke();
            };
        }
    }
}

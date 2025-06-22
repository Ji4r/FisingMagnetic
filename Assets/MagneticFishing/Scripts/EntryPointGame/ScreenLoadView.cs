using UnityEngine;

namespace MagneticFishing
{
    public class ScreenLoadView : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Transform uiSceneContainer;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen() 
        {
            loadingScreen.SetActive(false);
        }

        public void AttachSceneUi(GameObject sceneUI)
        {
            SceneClear();

            sceneUI.transform.SetParent(uiSceneContainer, false);
        }

        private void SceneClear()
        {
            var childCount = uiSceneContainer.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(uiSceneContainer.GetChild(i).gameObject);
            }
        }
    }
}

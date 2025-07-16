using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagneticFishing
{
    public class GameEntryPoint
    {   
        private static GameEntryPoint instance;
        private Corutines corutines;
        private ScreenLoadView screenLoadView;
        private ServiceSave serviceSave;
        private SaveOrLoadDataSystem saveOrLoadDataSystem;
        private SettingsGame settings;
        private SaveSystemsDataGame systemSave;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            instance = new GameEntryPoint();
            instance.RunGame();
        }

        private GameEntryPoint()
        {
            corutines = new GameObject("[Corutenes]").AddComponent<Corutines>();
            Object.DontDestroyOnLoad(corutines.gameObject);

            var prefabScreenLoadView = Resources.Load<ScreenLoadView>("ScreenLoad");
            screenLoadView = Object.Instantiate(prefabScreenLoadView);
            Object.DontDestroyOnLoad(screenLoadView.gameObject);



            saveOrLoadDataSystem = new GameObject("[SaveSystem]").AddComponent<SaveOrLoadDataSystem>();
            Object.DontDestroyOnLoad(saveOrLoadDataSystem.gameObject);

            settings = new GameObject("[SettingsGame]").AddComponent<SettingsGame>();
            Object.DontDestroyOnLoad(settings.gameObject);

            serviceSave = new GameObject("[ServiceSave]").AddComponent<ServiceSave>();
            Object.DontDestroyOnLoad(serviceSave.gameObject);

            systemSave = new GameObject("[SaveSystem]").AddComponent<SaveSystemsDataGame>();
            Object.DontDestroyOnLoad(systemSave.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == Scenes.GAMEPLAY)
            {
                corutines.StartCoroutine(LoadAndStartGameplay());

                return;
            }

            if (sceneName == Scenes.MENU)
            {
                corutines.StartCoroutine(LoadAndStartMenu());

                return;
            }

            if (sceneName != Scenes.BOOT)
            {
                return;
            }
#endif

            corutines.StartCoroutine(LoadAndStartMenu());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            SaveOrLoad();
            screenLoadView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);
            SaveOrLoad();
            yield return new WaitForSeconds(0.5f);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(screenLoadView);

            sceneEntryPoint.GoToMainMenuSceneRequested += () =>
            {
                corutines.StartCoroutine(LoadAndStartMenu());
            };

            screenLoadView.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMenu()
        {
            SaveOrLoad();
            screenLoadView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MENU);

            SaveOrLoad();
            yield return new WaitForSeconds(0.5f);

            var sceneEntryPoint = Object.FindFirstObjectByType<EntryPointMenu>();
            sceneEntryPoint.Run(screenLoadView);


            sceneEntryPoint.GoToGameplaySceneRequested += () =>
            {
                corutines.StartCoroutine(LoadAndStartGameplay());
            };

            screenLoadView.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private void SaveOrLoad()
        {
            IServiceLocator<IService> service = serviceSave.Locator;

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
        }
    }
}

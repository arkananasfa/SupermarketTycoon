using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{

    private static GameEntryPoint _instance;
    private CoroutineStarter _coroutineStarter;
    
    private UIRootView _uiRoot;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void StartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        _instance = new GameEntryPoint();
        _instance.RunGame();
    }

    private GameEntryPoint()
    {
        _coroutineStarter = new GameObject("[Coroutines]").AddComponent<CoroutineStarter>();
        Object.DontDestroyOnLoad(_coroutineStarter);
        
        var _uiRootPrefab = Resources.Load<UIRootView>("UIRoot");
        _uiRoot = Object.Instantiate(_uiRootPrefab);
        Object.DontDestroyOnLoad(_uiRoot.gameObject);
    }

    private void RunGame()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != Scenes.BOOT)
        {
            return;
        }
#endif
        
        _coroutineStarter.StartCoroutine(LoadAndStartGameplay()); 
    }

    private IEnumerator LoadAndStartGameplay()
    {
        _uiRoot.SetLoaderActive(true);

        yield return LoadSceneRoutine(Scenes.BOOT);
        yield return LoadSceneRoutine(Scenes.GAMEPLAY);

        yield return new WaitForSeconds(0.2f);
        
        var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
        sceneEntryPoint.Run();
        
        _uiRoot.SetLoaderActive(false);
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
    
}
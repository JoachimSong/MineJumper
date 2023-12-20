using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform playerTrans;
    public Vector3 lobbyPosition;

    [Header("Event Listening")]
    public SceneLoadEventSO loadEventSO;
    public VoidEventSO newGameEvent;
    public VoidEventSO restartGameEvent;
    public VoidEventSO backToMenuEvent;
    public VoidEventSO gameFinishEvent;

    [Header("Broadcast")]
    public VoidEventSO afterSceneLoadedEvent;
    public SceneLoadEventSO unloadedSceneEvent;

    [Header("Scene")]
    public GameSceneSO lobbyScene;
    public GameSceneSO currentLoadedScene;
    private GameSceneSO sceneToLoad;
    private Vector3 positionToGo;
    private bool fadeScreen;
    private bool isLoading;
    private void Awake()
    {

    }
    private void Start()
    {
        loadEventSO.RaiseLoadRequestEvent(lobbyScene, lobbyPosition);
    }
    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
    }

    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }

    private void OnLoadRequestEvent(GameSceneSO mapToLoad, Vector3 posToGo)
    {
        //string sceneName = sceneToLoad.name;
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        //// 循环检查加载进度
        //while (!asyncOperation.isDone)
        //{
        //    // 更新进度条或显示加载动画等
        //    float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
        //    Debug.Log("Loading progress: " + progress);
        //}
        sceneToLoad = mapToLoad;
        positionToGo = posToGo;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        if(currentLoadedScene != null)
        {
            yield return SceneManager.UnloadSceneAsync(currentLoadedScene.scenePath);
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.scenePath, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        currentLoadedScene = sceneToLoad;
        playerTrans.position = positionToGo;
        playerTrans.gameObject.GetComponent<PlayerController>().Reset();
        Debug.Log("场景加载完成！");
    }

    //private void OnLoadRequestEvent(GameSceneSO mapToLoad, Vector3 posToGo)
    //{
    //    if (isLoading)
    //    {
    //        return;
    //    }
    //    isLoading = true;
    //    sceneToLoad = mapToLoad;
    //    positionToGo = posToGo;
    //    if (currentLoadedScene != null)
    //    {
    //        StartCoroutine(UnloadPreviousScene());
    //    }
    //    else
    //    {
    //        LoadNewScene();
    //    }
    //}

    //private IEnumerator UnloadPreviousScene()
    //{
    //    unloadedSceneEvent.RaiseLoadRequestEvent(sceneToLoad, positionToGo);

    //    yield return currentLoadedScene.sceneReference.UnLoadScene();


    //    playerTrans.gameObject.SetActive(false);

    //    LoadNewScene();
    //}
    //private void LoadNewScene()
    //{
    //    var loadingOption = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
    //    loadingOption.Completed += OnLoadCompleted;
    //}

    //private void OnLoadCompleted(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<SceneInstance> obj)
    //{
    //    currentLoadedScene = sceneToLoad;
    //    playerTrans.position = positionToGo;
    //    playerTrans.gameObject.SetActive(true);

    //    if (fadeScreen)
    //    {
    //        fadeEvent.FadeOut(fadeDuration);
    //    }
    //    isLoading = false;

    //    if (currentLoadedScene.sceneType == SceneType.Map)
    //    {
    //        //场景加载完成后调用
    //        afterSceneLoadedEvent?.RaisedEvent();
    //    }
    //}

}
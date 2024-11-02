using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        GameObject levelOneButton = GameObject.FindWithTag("LevelOne");
        Button buttonComponent = levelOneButton?.GetComponent<Button>();
        buttonComponent?.onClick.AddListener(LoadFirstLevel);
    }

    public void LoadFirstLevel()
    {
        StartCoroutine(LoadGameScene("GameScene"));
    }

    private IEnumerator LoadGameScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ReturnToStartScreen()
    {
        StartCoroutine(LoadStartScene("StartScene"));
    }

    private IEnumerator LoadStartScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            GameObject exitButton = GameObject.FindWithTag("ExitButton");
            Button buttonComponent = exitButton?.GetComponent<Button>();
            buttonComponent?.onClick.AddListener(ReturnToStartScreen);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

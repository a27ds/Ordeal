using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance = null;
    public GameObject blackSquare;
    SpriteRenderer blackSquareSpriteRenderer;
    float fadeSpeed = 1.5f;
    string sceneToLoad;
    AsyncOperation async;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        blackSquareSpriteRenderer = blackSquare.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        FadeFromBlack();
        SceneManager.activeSceneChanged += SceneManager_ActiveSceneChanged;
    }

    public void FadeFromBlack()
    {
        GetCameraPos();
        Color squareColor = blackSquareSpriteRenderer.color;
        squareColor.a = 1;
        blackSquareSpriteRenderer.color = squareColor;
        blackSquare.SetActive(true);
        LeanTween.alpha(blackSquare, 0, fadeSpeed).setEaseInCubic().setOnComplete(() =>
        {
            blackSquare.SetActive(false);
        });
    }

    public void FadeToBlackAndLoadLevel(string levelToLoad)
    {
        GetCameraPos();
        Color color = blackSquareSpriteRenderer.color;
        color.a = 0;
        blackSquareSpriteRenderer.color = color;
        blackSquare.SetActive(true);
        LeanTween.alpha(blackSquare, 1, fadeSpeed).setEaseInCubic().setOnComplete(() =>
        {
            SceneManager.LoadScene(levelToLoad);
        });
    }

    void FadeToBlack()
    {
        GetCameraPos();
        Color color = blackSquareSpriteRenderer.color;
        color.a = 0;
        blackSquareSpriteRenderer.color = color;
        blackSquare.SetActive(true);
        LeanTween.alpha(blackSquare, 1, fadeSpeed).setEaseInCubic().setOnComplete(() =>
        {
            async.allowSceneActivation = true;
        });
    }

    public void ChangeScene(string scene)
    {
        sceneToLoad = scene;
        FadeToBlackAndLoadLevel("LoadingScene");
    }

    void SceneManager_ActiveSceneChanged(Scene arg0, Scene arg1)
    {
        if (SceneManager.GetActiveScene().name != "LoadingScene")
        {
            FadeFromBlack();
        }
        else
        {
            StartCoroutine(LoadSceneAndChange(sceneToLoad));
        }
    }

    IEnumerator LoadSceneAndChange(string sceneName)
    {
        yield return null;
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        yield return new WaitForSeconds(6.0f);
        FadeToBlack();
    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SceneManager_ActiveSceneChanged;
    }

    public void GetCameraPos()
    {
        float x = Camera.main.transform.position.x;
        float y = Camera.main.transform.position.y;
        blackSquare.transform.position = new Vector3(x, y, 0);
    }

}

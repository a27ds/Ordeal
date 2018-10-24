using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingGhosts : MonoBehaviour
{
    public GameObject ghost;
    public GameObject loadingText;

    public float speed = 0.2f;
    public int maximunNumberOfLoadingGhosts = 20;
    int numberOfLoadingGhosts;
    float randomScreenHeight;

    //public int screenWidth { get; private set; }

    void Start()
    {
        GameObject.Find("SceneHandler(Clone)").GetComponent<SceneHandler>().FadeFromBlack();
        LayoutTheLoadingWindow();
        StartCoroutine(LoadingAni());
        StartCoroutine(FlashingText());
    }

    IEnumerator FlashingText()
    {
        while (true)
        {
            LeanTween.alpha(loadingText, 0.0f, 0.6f);
            yield return new WaitForSecondsRealtime(0.6f);
            LeanTween.alpha(loadingText, 1.0f, 0.6f);
            yield return new WaitForSecondsRealtime(0.6f);
        }
    }

    IEnumerator LoadingAni()
    {
        while (numberOfLoadingGhosts <= maximunNumberOfLoadingGhosts)
        {
            numberOfLoadingGhosts++;
            SetLoadingGhostsAndMakeThemMove();
            yield return new WaitForSecondsRealtime(0.3f);
        }
    }

    void SetLoadingGhostsAndMakeThemMove()
    {
        GameObject newGhost;
        Vector3 pos;
        Vector3 moveToPos;

        randomScreenHeight = Random.Range(300, GameManager.screenHeight - 100);
        if (Random.Range(0, 2) == 1)
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(-40, randomScreenHeight, 10));
            moveToPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth + 40, randomScreenHeight, 10));
            newGhost = Instantiate(ghost, pos, Quaternion.Euler(0, 180, 0), transform);
        }
        else
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth + 40, randomScreenHeight, 10));
            moveToPos = Camera.main.ScreenToWorldPoint(new Vector3(-40, randomScreenHeight, 10));
            newGhost = Instantiate(ghost, pos, Quaternion.Euler(0, 0, 0), transform);
        }
        LeanTween.move(newGhost, moveToPos, speed).setEaseInOutQuad().setOnComplete(() =>
        {
            Destroy(newGhost);
        });
    }

    void LayoutTheLoadingWindow()
    {
        Vector3 loadingTextPos = Camera.main.ScreenToWorldPoint(new Vector3(50, 50, 10));
        loadingText.transform.position = loadingTextPos;
    }
}

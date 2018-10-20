using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingGhosts : MonoBehaviour
{

    public GameObject ghost;
    public TextMeshPro loadingText;

    public float speed = 0.2f;
    public int maximunNumberOfLoadingGhosts = 20;
    int numberOfLoadingGhosts;
    float screenWidth;
    float screenHeight;
    float randomScreenHeight;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().FadeFromBlack();
        loadingText.sortingOrder = 300;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        StartCoroutine(LoadingAni());
    }

    void flashingText()
    {
        //Gör så att texten går upp och ner i alphan
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

        randomScreenHeight = Random.Range(300, screenHeight-100);
        if (Random.Range(0, 2) == 1)
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(-40, randomScreenHeight, 10));
            moveToPos = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth + 40, randomScreenHeight, 10));
            newGhost = Instantiate(ghost, pos, Quaternion.Euler(0, 180, 0), transform);
        }
        else
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth + 40, randomScreenHeight, 10));
            moveToPos = Camera.main.ScreenToWorldPoint(new Vector3(-40, randomScreenHeight, 10));
            newGhost = Instantiate(ghost, pos, Quaternion.Euler(0, 0, 0), transform);
        }
        LeanTween.move(newGhost, moveToPos, speed).setEaseInOutQuad().setOnComplete(() => {
            Destroy(newGhost);
        });
    }
}

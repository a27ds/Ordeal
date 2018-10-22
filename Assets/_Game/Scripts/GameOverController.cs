using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject quitButton;
    public GameObject restartButton;

    void Start()
    {
        LayoutTheGameOverWindow();
    }

    void LayoutTheGameOverWindow()
    {
        Vector3 gameOverTextPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth / 2, GameManager.screenHeight / 2 + 200, 10));
        Vector3 quitButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth / 2 - 400, GameManager.screenHeight / 2 - 300, 10));
        Vector3 restartButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth / 2 + 400, GameManager.screenHeight / 2 - 300, 10));

        gameOverText.transform.position = gameOverTextPos;
        quitButton.transform.position = quitButtonPos;
        restartButton.transform.position = restartButtonPos;
    }
}

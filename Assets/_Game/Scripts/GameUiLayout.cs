using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUiLayout : MonoBehaviour
{
    public GameObject crossController;
    public GameObject pauseButton;
    public GameObject aButton;
    public GameObject bButton;
    public GameObject lives;
    public GameObject battery;
    public GameObject keyView;

    void Start()
    {
        LayoutGameUI();
    }

    void LayoutGameUI()
    {
        Vector3 crossControllerPos = Camera.main.ScreenToWorldPoint(new Vector3(150, 150, 10));
        Vector3 pauseButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(100, GameManager.screenHeight - 100, 10));
        Vector3 aButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 450, 200, 10));
        Vector3 bButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 200, 350, 10));
        Vector3 livesPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 100, GameManager.screenHeight - 100, 10));
        Vector3 batteryPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 230, GameManager.screenHeight - 230, 10));
        Vector3 keyViewPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 95, GameManager.screenHeight - 360, 10));

        crossController.transform.position = crossControllerPos;
        pauseButton.transform.position = pauseButtonPos;
        aButton.transform.position = aButtonPos;
        bButton.transform.position = bButtonPos;
        lives.transform.position = livesPos;
        battery.transform.position = batteryPos;
        keyView.transform.position = keyViewPos;
    }
}

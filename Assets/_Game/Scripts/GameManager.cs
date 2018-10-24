using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static float screenHeight;
    public static float screenWidth;
    public GameObject gameOverScreen;
    GameObject newGameOverScreen;

    void OnEnable()
    {
        LifeViewController.Dead += LifeViewController_Dead;
    }

    void OnDisable()
    {
        LifeViewController.Dead -= LifeViewController_Dead;
    }

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
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        Debug.Log(screenHeight);
    }

    void LifeViewController_Dead()
    {
        newGameOverScreen = Instantiate(gameOverScreen);
        GetCameraPos();
    }

    public void GetCameraPos()
    {
        float x = Camera.main.transform.position.x;
        float y = Camera.main.transform.position.y;
        newGameOverScreen.transform.position = new Vector3(x, y, 0);
    }
}

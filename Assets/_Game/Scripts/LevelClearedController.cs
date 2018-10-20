﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClearedController : MonoBehaviour {

    string levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("LEVEL CLEARED");
            WhatLevelWillBeLoaded();
        }
    }

    void WhatLevelWillBeLoaded()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                {
                    levelToLoad = "Level2";
                    break;
                }
            case "Level2":
                {
                    levelToLoad = "MainMenu";
                    break;
                }
            default:
                break;
        }
        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScene(levelToLoad);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject sceneHandler;

	void Awake()
    {
        if (SceneHandler.instance == null)
        {
            Instantiate(sceneHandler);
        }
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
}

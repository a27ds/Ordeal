using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("SceneHandler(Clone)").GetComponent<SceneHandler>().ChangeScene(SceneManager.GetActiveScene().name);
    }
}

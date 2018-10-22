using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMainMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("SceneHandler(Clone)").GetComponent<SceneHandler>().ChangeScene("MainMenu");
    }
}

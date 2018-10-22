using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("SceneHandler(Clone)").GetComponent<SceneHandler>().ChangeScene("Level1");
    }
}

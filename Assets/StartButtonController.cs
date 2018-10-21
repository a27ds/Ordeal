using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScene("Level1");
    }
}

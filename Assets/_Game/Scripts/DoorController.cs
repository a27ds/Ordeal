using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    SpriteRenderer doorSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        doorSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator OpenDoor()
    {
        bool doorClosed = true;
        while (doorClosed)
        {
            doorSpriteRenderer.color -= new Color(0, 0, 0, 0.05f);
            yield return null;
            if (doorSpriteRenderer.color.a <= 0)
            {
                doorClosed = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void PlayerOpenDoor()
    {
        StartCoroutine(OpenDoor());
    }

}

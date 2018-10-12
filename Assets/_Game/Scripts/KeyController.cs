﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    SpriteRenderer keySpriteRenderer;

	// Use this for initialization
	void Start () {
        keySpriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void KeyIsPickedUp()
    {
        StartCoroutine(KeyIsPickedUpAnim());
    }

    IEnumerator KeyIsPickedUpAnim()
    {
        Debug.Log("Key is picked Up");
        bool keyOnGround = true;
        while (keyOnGround)
        {
            keySpriteRenderer.color -= new Color(0, 0, 0, 0.1f);
            yield return null;
            if (keySpriteRenderer.color.a <= 0)
            {
                keyOnGround = false;
                Destroy(gameObject);
            }
        }
    }

}

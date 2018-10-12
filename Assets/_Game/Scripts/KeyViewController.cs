﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyViewController : MonoBehaviour {

    public GameObject keyInViewPrefab;

    public int keys;
    int maxKeys = 5;
    public float distance = 0.65f;

    private void Start()
    {
        for (int i = 0; i < maxKeys; i++)
        {
            GameObject newKey = Instantiate(keyInViewPrefab, transform);
            Vector3 pos = gameObject.transform.position;
            pos.x -= i * distance;
            newKey.SetActive(false);
            newKey.transform.position = pos;
        }
    }

    public void GotAKey()
    {
        transform.GetChild(keys).gameObject.SetActive(true);
        keys++;
    }

    public void UseOneKey()
    {
        transform.GetChild(keys - 1).gameObject.SetActive(false);
        keys--;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeViewController : MonoBehaviour {

    public GameObject heartPrefab;
    public int lives = 4;
    public float distance = 0.65f;

    private void Start()
    {
        for (int i = 0; i < lives; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab);
            newHeart.transform.SetParent(transform);
            Vector3 pos = gameObject.transform.position;
            pos.x -= (i * distance);
            newHeart.transform.position = pos;
        }
    }

    public bool RemoveLife()
    {
        lives--;
        transform.GetChild(lives).gameObject.SetActive(false);

        if (lives == 0)
            return false;

        return true;
    }

    public void RestoreAllLives()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}

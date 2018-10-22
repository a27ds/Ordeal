using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeViewController : MonoBehaviour
{
    public delegate void PlayerDead();
    public static event PlayerDead Dead;

    public GameObject heartPrefab;

    OptionsController optionsController;
    float distance = 0.65f;
    int livesInPlay;

    void OnEnable()
    {
        Player.LoseOneLife += Player_LoseOneLife;
        Player.RestoreOneLife += Player_RestoreOneLife;
        Player.RestoreAllLives += Player_RestoreAllLives;
        Player.LoseOneSecondFromOnelives += Player_LoseOneSecondFromOnelives;
    }

    void OnDisable()
    {
        Player.LoseOneLife -= Player_LoseOneLife;
        Player.RestoreOneLife -= Player_RestoreOneLife;
        Player.RestoreAllLives -= Player_RestoreAllLives;
        Player.LoseOneSecondFromOnelives -= Player_LoseOneSecondFromOnelives;
    }

    void Start()
    {
        optionsController = GameObject.Find("Options").GetComponent<OptionsController>();
        livesInPlay = optionsController.lives;
        for (int i = 0; i < optionsController.lives; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab);
            newHeart.transform.SetParent(transform);
            Vector3 pos = gameObject.transform.position;
            pos.x -= i * distance;
            newHeart.transform.position = pos;
        }
    }

    void Player_LoseOneSecondFromOnelives()
    {
        transform.GetChild(livesInPlay - 1).gameObject.transform.localScale *= 0.8f;
    }

    void Player_LoseOneLife()
    {
        RemoveLife();
    }

    void Player_RestoreOneLife()
    {
    }

    void Player_RestoreAllLives()
    {
        RestoreAllLives();
    }

    public void RemoveLife()
    {
        livesInPlay--;
        transform.GetChild(livesInPlay).gameObject.SetActive(false);

        if (livesInPlay == 0)
        {
            Dead();
        }
    }

    public void RestoreAllLives()
    {
        livesInPlay = optionsController.lives;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}

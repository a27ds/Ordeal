using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    public GameObject player;
    public ParticleSystem ghostPopped;

    public float lifeInSecond;
    public float timeInLight;

    bool isGhostDead;
    bool moveGhost;

    SpriteRenderer GhostSpriteRender;

    private void OnEnable()
    {
        LifeViewController.Dead += LifeViewController_Dead;
    }

    private void OnDisable()
    {
        LifeViewController.Dead -= LifeViewController_Dead;
    }

    void LifeViewController_Dead()
    {
        Destroy(gameObject);
    }


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        isGhostDead = false;
        GhostSpriteRender = GetComponent<SpriteRenderer>();
        lifeInSecond = 0.5f;
        StartCoroutine(GhostAppear());
    }
	
	// Update is called once per frame
	void Update () {
        if (moveGhost)
        {
            GetComponent<NavMeshAgent2D>().destination = player.transform.position;
        }
        if (timeInLight >= lifeInSecond)
        {
            moveGhost = false;
            if (!isGhostDead)
            {
                StartCoroutine(GhostGotPopped());
            }
        }
	}

    IEnumerator GhostAppear()
    {
        ghostPopped.gameObject.SetActive(true);
        ghostPopped.Play(true);
        yield return new WaitForSecondsRealtime(0.5f);
        ghostPopped.Stop(true);
        yield return new WaitForSecondsRealtime(1.0f);
        moveGhost = true;
    }

    IEnumerator GhostGotPopped()
    {
        moveGhost = false;
        isGhostDead = true;
        GhostSpriteRender.color = new Color(0, 0, 0, 0);
        ghostPopped.gameObject.SetActive(true);
        ghostPopped.Play(true);
        yield return new WaitForSecondsRealtime(1.0f);
        ghostPopped.Stop(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Light(Clone)"))
        {
            timeInLight += Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Light(Clone)"))
        {
            timeInLight += Time.deltaTime;
        }
    }
}

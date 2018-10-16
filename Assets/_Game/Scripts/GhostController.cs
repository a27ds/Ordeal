using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    public GameObject player;
    public ParticleSystem ghostPopped;

    //public float lifeInSecond;
    float timeInLight;
    public bool isGhostDead;
    bool moveGhost;
    NavMeshAgent2D ghostAgent;
    OptionsController optionsController;
    Animator anim;

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
        optionsController = GameObject.Find("Options").GetComponent<OptionsController>();
        ghostAgent = GetComponent<NavMeshAgent2D>();
        ghostAgent.speed = optionsController.ghostSpeed;
        anim = gameObject.GetComponent<Animator>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        isGhostDead = false;
        GhostSpriteRender = GetComponent<SpriteRenderer>();
        StartCoroutine(GhostAppear());
    }
	
	// Update is called once per frame
	void Update () {
        if (moveGhost)
        {
            ghostAgent.destination = player.transform.position;
            AnimateGhost();


        }
        if (timeInLight >= optionsController.ghostLifeInSecond)
        {
            ghostAgent.isStopped = true;
            moveGhost = false;
            if (!isGhostDead)
            {
                StartCoroutine(GhostGotPopped());
            }
        }
	}

    void AnimateGhost()
    {
        if (ghostAgent.velocity.x > .5f)
        {
            anim.Play("ghost_right");
        }
        else if (ghostAgent.velocity.x < -.5f)
        {
            anim.Play("ghost_left");
        }
        else if (ghostAgent.velocity.y > .5f)
        {
            anim.Play("ghost_up");
        }
        else if (ghostAgent.velocity.y < -.5f)
        {
            anim.Play("ghost_down");
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

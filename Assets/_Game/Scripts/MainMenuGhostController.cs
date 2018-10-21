using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGhostController : MonoBehaviour {

    Vector3 lastPos;
    Animator anim;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        lastPos = transform.position;
	}

	void Update () {
        var velocity = transform.position - lastPos;
        lastPos = transform.position;
        AnimateGhost(velocity);
    }

    void AnimateGhost(Vector3 velocity)
    {
        if (velocity.x > .001f)
        {
            anim.Play("ghost_right");
        }
        else if (velocity.x < -.001f)
        {
            anim.Play("ghost_left");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour {

    public ParticleSystem lampParticlePrefab;
    ParticleSystem lampParticle;
    GameObject lampLight;
    Vector3 lastPos;
    Animator anim;

    void Start () {
        lampLight = GameObject.Find("light MainMenu");
        anim = gameObject.GetComponent<Animator>();
        lastPos = transform.position;
        lampParticle = Instantiate(lampParticlePrefab, transform);

    }
	
	void Update () {
        var velocity = transform.position - lastPos;
        lastPos = transform.position;
        AnimatePlayer(velocity);
        SetPosAndRotationForLampParticle();
    }

    void AnimatePlayer(Vector3 velocity)
    {
        if (velocity.x > .001f)
        {
            anim.Play("walk_right");
        }
        else if (velocity.x < -.001f)
        {
            anim.Play("walk_left");
        }
        else if (velocity.y > .001f)
        {
            anim.Play("walk_left");
        }
        else if (velocity.y < -.001f)
        {
            anim.Play("walk_down");
        }
    }

    void SetPosAndRotationForLampParticle()
    {
        lampParticle.gameObject.transform.position = lampLight.transform.position;
        lampParticle.gameObject.transform.rotation = lampLight.transform.rotation;
    }
}

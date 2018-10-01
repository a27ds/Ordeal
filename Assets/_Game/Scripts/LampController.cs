using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    readonly AnimateLampDirection animateLampDirection;
    GameObject player;
    Animator playerAnimator;

    public GameObject lampLight;
    bool isLampOn = false;

    // Use this for initialization
    void Start()
    {
        lampLight = Instantiate(lampLight, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, -90), GameObject.Find("Lamp").transform);
        lampLight.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        lampLight.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        player = transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();

        AnimateLampDirection[] animateLampDirectionArray = playerAnimator.GetBehaviours<AnimateLampDirection>();
        foreach (var a in animateLampDirectionArray)
        {
            a.light = lampLight;
        }
    }

    public void SwitchOnOrOffLight(bool state)
    {
        if (state && !isLampOn)
        {
            isLampOn = true;
            lampLight.SetActive(true);
            LeanTween.scale(lampLight, new Vector3(1f, 1f, 1f), 0.2f).setEaseInOutCubic();
        }
        else if (!state && isLampOn)
        {
            LeanTween.scale(lampLight, new Vector3(0.0f, 0.0f, 0.0f), 0.2f).setOnComplete(() =>
            {
                lampLight.SetActive(false);
                isLampOn = false;
            }).setEaseInOutCubic();
        }
    }
}

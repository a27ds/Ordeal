using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    readonly AnimateLampDirection animateLampDirection;
    GameObject player;
    Animator playerAnimator;

    public GameObject lampLight;
    public ParticleSystem lampParticle;
    public BatteryController battery;
    public bool isLampOn = false;
    public bool switchOnOrOff = false;

    // Use this for initialization
    void Start()
    {
        lampParticle.gameObject.SetActive(false);

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

    private void Update()
    {
            SwitchOnOrOffLight(switchOnOrOff);
    }

    public void SetPosAndRotationForLampParticle()
    {
        lampParticle.gameObject.transform.position = lampLight.transform.position;
        lampParticle.gameObject.transform.rotation = lampLight.transform.rotation;
    }

    public void SwitchOnOrOffLight(bool state)
    {

        SetPosAndRotationForLampParticle();
        if (state && !isLampOn)
        {
            if (!lampParticle.gameObject.activeSelf)
            {
                lampParticle.gameObject.SetActive(true);
            }
            if (!battery.isBatteryDead)
            {
                lampParticle.Play();
                isLampOn = true;
                lampLight.SetActive(true);
                LeanTween.scale(lampLight, new Vector3(1f, 1f, 1f), 0.2f).setEaseInOutCubic();
            }
        }
        else if (!state && isLampOn)
        {
                LeanTween.scale(lampLight, new Vector3(0.0f, 0.0f, 0.0f), 0.2f).setOnComplete(() =>
                {
                lampParticle.Stop();
                    lampLight.SetActive(false);
                    isLampOn = false;
                }).setEaseInOutCubic();
        }
    }
}

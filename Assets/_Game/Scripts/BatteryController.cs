using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryController : MonoBehaviour
{

    public LampController Lamp;
    public GameObject BatteryMeter;
    public OptionsController optionsController;

    float batteryInPercent;
    float onePercentInSeconds;
    float rechargingModifyer;

    bool isLampOn;
    bool batteryIsBeingDrained = false;

    [HideInInspector]
    public bool isBatteryDead = false;

    // Use this for initialization
    void Start()
    {
        Lamp = Lamp.GetComponent<LampController>();
        BatteryMeter = BatteryMeter.gameObject;

        batteryInPercent = 100.0f;
        rechargingModifyer = 1.5f;

        onePercentInSeconds = optionsController.batteryLengthInSeconds / batteryInPercent;
    }

    // Update is called once per frame
    void Update()
    {
        isLampOn = Lamp.isLampOn;
        if (batteryInPercent <= 0 && !isBatteryDead)
        {
            StartCoroutine(DeadBattery());
        }
        else
        {
            if (!batteryIsBeingDrained && isLampOn)
            {
                StartCoroutine(DrainBattery());
            }
            else if (batteryIsBeingDrained && !isLampOn)
            {
                StartCoroutine(RechargingBattery());
            }
        }
    }

    public IEnumerator DrainBattery()
    {
        while (batteryInPercent >= 1 && isLampOn)
        {
            batteryIsBeingDrained = true;
            batteryInPercent--;
            ScaleBatteryMeter();
            yield return new WaitForSecondsRealtime(onePercentInSeconds);
        }
    }

    public IEnumerator RechargingBattery()
    {
        float timeToRechargeOnePercentInSeconds = onePercentInSeconds * rechargingModifyer;
        while (batteryInPercent <= 99 && !isLampOn)
        {
            batteryIsBeingDrained = false;
            batteryInPercent++;
            if (batteryInPercent >= 99)
            {
                isBatteryDead = false;
            }
            ScaleBatteryMeter();
            yield return new WaitForSecondsRealtime(timeToRechargeOnePercentInSeconds);
        }
    }

    void ScaleBatteryMeter()
    {
        Vector3 scaleTheMeter = new Vector3(batteryInPercent / 100, 1, 1);
        LeanTween.scale(BatteryMeter, scaleTheMeter, 0.0f);
        if (batteryInPercent <= 30)
        {
            BatteryMeter.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            BatteryMeter.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public IEnumerator DeadBattery()
    {
        isLampOn = false;
        isBatteryDead = true;
        Lamp.lampLight.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Lamp.lampLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        Lamp.lampLight.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Lamp.lampLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        Lamp.lampLight.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        Lamp.lampLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        Lamp.lampLight.SetActive(false);
        yield return new WaitForSecondsRealtime(0.3f);
        Lamp.lampLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        Lamp.lampLight.SetActive(false);
        StartCoroutine(RechargingBattery());
    }
}
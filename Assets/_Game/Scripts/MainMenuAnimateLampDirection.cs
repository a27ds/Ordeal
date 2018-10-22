using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimateLampDirection : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject newLight = GameObject.Find("light MainMenu");
        SpriteRenderer lightSpriteRenderer = newLight.GetComponent<SpriteRenderer>();

        if (stateInfo.IsTag("down"))
        {
            newLight.transform.localPosition = new Vector3(0.152f, -0.109f, 0.0f);
            newLight.transform.localRotation = Quaternion.Euler(0, 0, -90);
            lightSpriteRenderer.sortingOrder = 51;
        }

        if (stateInfo.IsTag("left"))
        {
            newLight.transform.localPosition = new Vector3(-0.171f, -0.122f, 0.0f);
            newLight.transform.localRotation = Quaternion.Euler(0, 0, -180);
            lightSpriteRenderer.sortingOrder = 51;
        }

        if (stateInfo.IsTag("right"))
        {
            newLight.transform.localPosition = new Vector3(0.159f, -0.118f, 0.0f);
            newLight.transform.localRotation = Quaternion.Euler(0, 0, 0);
            lightSpriteRenderer.sortingOrder = 51;
        }
    }
}

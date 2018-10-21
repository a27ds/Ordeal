using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimateLampDirection: StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject newLight = GameObject.Find("light MainMenu");
        
        SpriteRenderer lightSpriteRenderer = newLight.GetComponent<SpriteRenderer>();


        //if (stateInfo.IsTag("up"))
        //{
        //    newLight.transform.localPosition = new Vector3(-0.115f, -0.082f, 0.0f);
        //    newLight.transform.localRotation = Quaternion.Euler(0, 0, 90);
        //    lightSpriteRenderer.sortingOrder = 49;
        //}
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

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
	//}

   
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	//}


	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    //}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	// override public v

    // StateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	//}
}

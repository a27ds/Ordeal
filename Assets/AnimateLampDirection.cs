using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLampDirection : StateMachineBehaviour {

    //public LampController lampController;
    public GameObject light;
    public LayerMask worldLayerMask;
    Vector2 direction = new Vector2(0.0f, 0.0f);

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer lightSpriteRenderer = light.GetComponent<SpriteRenderer>();

        if (stateInfo.IsTag("up"))
        {
            direction = new Vector2(0.0f, 1.0f);
            light.transform.localPosition = new Vector3(-0.115f, -0.082f, 0.0f);
            light.transform.localRotation = Quaternion.Euler(0, 0, 90);
            lightSpriteRenderer.sortingOrder = 49;
        }
        if (stateInfo.IsTag("down"))
        {
            direction = new Vector2(0.0f, -1.0f);
            light.transform.localPosition = new Vector3(0.152f, -0.109f, 0.0f);
            light.transform.localRotation = Quaternion.Euler(0, 0, -90);
            lightSpriteRenderer.sortingOrder = 51;
        }
        if (stateInfo.IsTag("left"))
        {
            direction = new Vector2(-1.0f, 0.0f);
            light.transform.localPosition = new Vector3(-0.171f, -0.122f, 0.0f);
            light.transform.localRotation = Quaternion.Euler(0, 0, -180);
            lightSpriteRenderer.sortingOrder = 51;
        }
        if (stateInfo.IsTag("right"))
        {
            direction = new Vector2(1.0f, 0.0f);
            light.transform.localPosition = new Vector3(0.159f, -0.118f, 0.0f);
            light.transform.localRotation = Quaternion.Euler(0, 0, 0);
            lightSpriteRenderer.sortingOrder = 51;
        }
        RaycastAndScaleLight();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        RaycastAndScaleLight();
    }

    void RaycastAndScaleLight()
    {
        RaycastHit2D lampHit = Physics2D.Raycast(light.transform.position, direction, 1.5f, worldLayerMask);
        if (lampHit.collider != null)
        {
            if (lampHit.distance <= 1.5f)
            {
                float scaleNumber = 0.45f * lampHit.distance + 0.26f;
                Vector3 scale = Vector3.one * scaleNumber;
                light.transform.localScale = scale;
            }
        }
        else
        {
            LeanTween.scale(light, new Vector3(1f, 1f, 1f), 0.0f).setEaseInOutCubic();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	//}


	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    //}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

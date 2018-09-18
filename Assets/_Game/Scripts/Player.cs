using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float horizontalAxis;
    public static float verticalAxis;
    public float moveForce = 4;
    Rigidbody2D playerBody;
    Animator anim;
    int walkUpHash = Animator.StringToHash("walk_up");

    private void OnEnable()
    {
        TouchInput.UpPressed += TouchInput_UpPressed;
        TouchInput.DownPressed += TouchInput_DownPressed;
        TouchInput.RightPressed += TouchInput_RightPressed;
        TouchInput.LeftPressed += TouchInput_LeftPressed;
        TouchInput.APressed += TouchInput_APressed;
        TouchInput.BPressed += TouchInput_BPressed;
    }

    private void OnDisable()
    {
        TouchInput.UpPressed -= TouchInput_UpPressed;
        TouchInput.DownPressed -= TouchInput_DownPressed;
        TouchInput.RightPressed -= TouchInput_RightPressed;
        TouchInput.LeftPressed -= TouchInput_LeftPressed;
        TouchInput.APressed -= TouchInput_APressed;
        TouchInput.BPressed -= TouchInput_BPressed;
    }

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckIfAnyKeysArePressed();
        playerBody.velocity = new Vector2(Mathf.Lerp(0, verticalAxis * moveForce, 0.8f),
                                          Mathf.Lerp(0, horizontalAxis * moveForce, 0.8f));
    }

    void CheckIfAnyKeysArePressed()
    {
        if (Input.GetKey("up"))
        {
            TouchInput_UpPressed();
        }
        if (Input.GetKey("down"))
        {
            TouchInput_DownPressed();
        }
        if (Input.GetKey("left"))
        {
            TouchInput_LeftPressed();
        }
        if (Input.GetKey("right"))
        {
            TouchInput_RightPressed();
        }
        if (Input.GetKeyUp("up") || Input.GetKeyUp("down"))
        {
            horizontalAxis = 0;
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
        {
            verticalAxis = 0;
        }
    }

    void TouchInput_UpPressed()
    {
        Debug.Log("up");
        anim.SetTrigger(walkUpHash);
        horizontalAxis = 1;
    }

    void TouchInput_DownPressed()
    {
        Debug.Log("down");
        horizontalAxis = -1;
    }

    void TouchInput_RightPressed()
    {
        Debug.Log("right");
        verticalAxis = 1;
    }

    void TouchInput_LeftPressed()
    {
        Debug.Log("left");
        verticalAxis = -1;
    }

    void TouchInput_APressed()
    {
        Debug.Log("a");
    }

    void TouchInput_BPressed()
    {
        Debug.Log("b");
    }

}

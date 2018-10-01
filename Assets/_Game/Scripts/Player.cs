using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerBody;
    Animator anim;
    public LampController lampController;

    public float verticalAxis;
    public float horizontalAxis;
    public float moveForce = 4;
    KeyPressed keyPressed = KeyPressed.free;

    enum KeyPressed { free, left, right, up, down };

    private void OnEnable()
    {
        InputController.UpPressed += TouchInput_UpPressed;
        InputController.DownPressed += TouchInput_DownPressed;
        InputController.RightPressed += TouchInput_RightPressed;
        InputController.LeftPressed += TouchInput_LeftPressed;
        InputController.APressed += TouchInput_APressed;
        InputController.BPressed += TouchInput_BPressed;
    }

    private void OnDisable()
    {
        InputController.UpPressed -= TouchInput_UpPressed;
        InputController.DownPressed -= TouchInput_DownPressed;
        InputController.RightPressed -= TouchInput_RightPressed;
        InputController.LeftPressed -= TouchInput_LeftPressed;
        InputController.APressed -= TouchInput_APressed;
        InputController.BPressed -= TouchInput_BPressed;
    }

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        playerBody.velocity = new Vector2(Mathf.Lerp(0, horizontalAxis * moveForce, 0.8f),
                                          Mathf.Lerp(0, verticalAxis * moveForce, 0.8f));
    }

    void TouchInput_UpPressed(bool pressed)
    {
        if (pressed && keyPressed == KeyPressed.free)
        {
            keyPressed = KeyPressed.up;
            verticalAxis = 1;
            anim.Play("walk_up");
        }
        else if (!pressed && keyPressed == KeyPressed.up)
        {
            keyPressed = KeyPressed.free;
            verticalAxis = 0;
            anim.Play("kid_up_idle");
        }
    }

    void TouchInput_DownPressed(bool pressed)
    {
        if (pressed && keyPressed == KeyPressed.free)
        {
            keyPressed = KeyPressed.down;
            verticalAxis = -1;
            anim.Play("walk_down");
        }
        else if (!pressed && keyPressed == KeyPressed.down)
        {
            keyPressed = KeyPressed.free;
            verticalAxis = 0;
            anim.Play("kid_down_idle");
        }
    }

    void TouchInput_RightPressed(bool pressed)
    {
        if (pressed && keyPressed == KeyPressed.free)
        {
            keyPressed = KeyPressed.right;
            horizontalAxis = 1;
            anim.Play("walk_right");
        }
        else if (!pressed && keyPressed == KeyPressed.right)
        {
            keyPressed = KeyPressed.free;
            horizontalAxis = 0;
            anim.Play("kid_right_idle");
        }
    }

    void TouchInput_LeftPressed(bool pressed)
    {
        if (pressed && keyPressed == KeyPressed.free)
        {
            keyPressed = KeyPressed.left;
            horizontalAxis = -1;
            anim.Play("walk_left");
        }
        else if (!pressed && keyPressed == KeyPressed.left)
        {
            keyPressed = KeyPressed.free;
            horizontalAxis = 0;
            anim.Play("kid_left_idle");
        }
    }

    void TouchInput_APressed(bool pressed)
    {
        if (pressed)
        {
            lampController.SwitchOnOrOffLight(true);
        }
        else
        {
            lampController.SwitchOnOrOffLight(false);
        }
    }

    void TouchInput_BPressed(bool pressed)
    {
        if (pressed)
        {
            Debug.Log("b");
        }
        else
        {

        }
    }
}

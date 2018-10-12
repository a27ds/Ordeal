﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public delegate void PlayerDelegate();
    public static event PlayerDelegate LoseOneLife;
    public static event PlayerDelegate RestoreOneLife;
    public static event PlayerDelegate RestoreAllLives;
    public static event PlayerDelegate LoseOneSecondFromOnelives;

    

    Rigidbody2D playerBody;
    Animator anim;
    public KeyViewController keyView;
    public LampController lampController;

    //public int keysToDoors;
    public float verticalAxis;
    public float horizontalAxis;
    public float moveForce = 1.5f;
    float timeTouchingGhosts;
    float oneSecondPassedBy;
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
        InputController.PausePressed += InputController_PausePressed;
        LifeViewController.Dead += LifeViewController_Dead;
    }

    private void OnDisable()
    {
        InputController.UpPressed -= TouchInput_UpPressed;
        InputController.DownPressed -= TouchInput_DownPressed;
        InputController.RightPressed -= TouchInput_RightPressed;
        InputController.LeftPressed -= TouchInput_LeftPressed;
        InputController.APressed -= TouchInput_APressed;
        InputController.BPressed -= TouchInput_BPressed;
        LifeViewController.Dead -= LifeViewController_Dead;
    }

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        CheckCollisions();

    }

    void CheckCollisions()
    {
        RaycastHit2D[] PlayerContact = new RaycastHit2D[1];
        playerBody.gameObject.GetComponent<Collider2D>().Cast(Vector2.zero, PlayerContact);

        if (PlayerContact[0] && PlayerContact[0].transform.gameObject.name.Equals("Ghost(Clone)"))
        {
            timeTouchingGhosts += Time.deltaTime;
            oneSecondPassedBy += Time.deltaTime;
            Debug.Log("HEY");
            if (oneSecondPassedBy >= 1.0f)
            {
                oneSecondPassedBy = 0;
                LoseOneSecondFromOnelives();
            }
               
            if (timeTouchingGhosts >= 5.0f)
            {
                oneSecondPassedBy = 0;
                timeTouchingGhosts = 0.0f;
                LoseOneLife();
            }
        }

    }

void LifeViewController_Dead()
    {
        Debug.Log("Player is Dead");
        gameObject.SetActive(false);
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
            lampController.switchOnOrOff = true;
        }
        else
        {
            lampController.switchOnOrOff = false;
        }
    }

    void TouchInput_BPressed(bool pressed)
    {
        if (pressed)
        {
            moveForce = 3.5f;
        }
        else
        {
            moveForce = 1.5f;
        }
    }

void InputController_PausePressed(bool b)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("DoorUp") || collision.gameObject.name.Equals("DoorDown") || collision.gameObject.name.Equals("DoorRight") || collision.gameObject.name.Equals("DoorLeft"))
        {
            TryToOpenDoorAndUseOneKey(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Key"))
        {
            PickUpKey(collision);
        }
    }

    void PickUpKey(Collider2D collision)
    {
        //keysToDoors++;
        //keyView.keys = keysToDoors;
        keyView.GotAKey();
        collision.gameObject.GetComponent<KeyController>().KeyIsPickedUp();
    }

    void TryToOpenDoorAndUseOneKey(Collision2D collision)
    {
        if (keyView.keys >= 1)
        {
            Debug.Log("Open the door and use one key");
            //keysToDoors--;
            //keyView.keys = keysToDoors;
            keyView.UseOneKey();
            collision.gameObject.GetComponent<DoorController>().PlayerOpenDoor();
        }
        else
        {
            Debug.Log("Can't open the door");
        }
    }

}

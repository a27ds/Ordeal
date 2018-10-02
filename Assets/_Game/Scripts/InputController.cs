using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void TouchInputPressed(bool b);
    public static event TouchInputPressed UpPressed;
    public static event TouchInputPressed DownPressed;
    public static event TouchInputPressed LeftPressed;
    public static event TouchInputPressed RightPressed;
    public static event TouchInputPressed APressed;
    public static event TouchInputPressed BPressed;
    public static event TouchInputPressed PausePressed;

    public string justPressedDPad = "";
    public int fingerIdPressedDPad = -1;

    //public LayerMask touchInputMask; Använda mig av detta?

    void Update()
    {
        CheckIfAnyKeysArePressed();
        CheckTouches();
    }

    void CheckTouches()
    {
        if (Input.touches != null)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit2D = Physics2D.Raycast(pos, Vector2.zero);
                if (hit2D.collider != null)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (hit2D.collider.tag.Equals("Up") || hit2D.collider.tag.Equals("Down") || hit2D.collider.tag.Equals("Left") || hit2D.collider.tag.Equals("Right"))
                        {
                            fingerIdPressedDPad = touch.fingerId;
                            justPressedDPad = hit2D.collider.tag;
                        }
                        WhichButton(hit2D.collider.tag);
                    }

                    else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && !hit2D.collider.tag.Equals("Pause"))
                    {

                        if (justPressedDPad != hit2D.collider.tag && fingerIdPressedDPad == touch.fingerId)
                        {
                            StopPressingDPpad(justPressedDPad);
                            WhichButton(hit2D.collider.tag);
                        }
                        if (hit2D.collider.tag.Equals("Up") || hit2D.collider.tag.Equals("Down") || hit2D.collider.tag.Equals("Left") || hit2D.collider.tag.Equals("Right"))
                        {
                            fingerIdPressedDPad = touch.fingerId;
                            justPressedDPad = hit2D.collider.tag;
                        }
                        WhichButton(hit2D.collider.tag);
                    }

                    else if (touch.phase == TouchPhase.Ended)
                    {
                        if (fingerIdPressedDPad == touch.fingerId)
                        {
                            StopPressingDPpad(justPressedDPad);
                        }
                        else
                        {
                            StopPressingABOrPause(hit2D.collider.tag);
                        }

                    }
                }
                else if (fingerIdPressedDPad == touch.fingerId)
                {
                    StopPressingDPpad(justPressedDPad);
                }
            }
        }
    }

    void StopPressingABOrPause(string whichTag)
    {
        switch (whichTag)
        {
            case "A":
                {
                    Debug.Log(whichTag);
                    APressed(false);
                    break;
                }
            case "B":
                {
                    Debug.Log(whichTag);
                    BPressed(false);
                    break;
                }
            case "Pause":
                {
                    Debug.Log(whichTag);
                    PausePressed(false);
                    break;
                }
        }
    }

    void StopPressingDPpad(string whichTag)
    {
        justPressedDPad = "";
        fingerIdPressedDPad = -1;
        switch (whichTag)
        {
            case "Up":
                {
                    UpPressed(false);
                    break;
                }
            case "Down":
                {
                    DownPressed(false);
                    break;
                }
            case "Left":
                {
                    LeftPressed(false);
                    break;
                }
            case "Right":
                {
                    RightPressed(false);
                    break;
                }
            //case "A":
            //    {
            //        APressed(false);
            //        break;
            //    }
            //case "B":
                //{
                //    BPressed(false);
                //    break;
                //}
            default:
                break;
        }
    }

    void WhichButton(string whichTag)
    {
        switch (whichTag)
        {
            case "Up":
                {
                    if (UpPressed != null)
                        UpPressed(true);
                    break;
                }
            case "Down":
                {
                    if (DownPressed != null)
                        DownPressed(true);
                    break;
                }
            case "Left":
                {
                    if (LeftPressed != null)
                        LeftPressed(true);
                    break;
                }
            case "Right":
                {
                    if (RightPressed != null)
                        RightPressed(true);
                    break;
                }
            case "A":
                {
                    if (APressed != null)
                        APressed(true);
                    break;
                }
            case "B":
                {
                    if (BPressed != null)
                        BPressed(true);
                    break;
                }
            case "Pause":
                {
                    if (PausePressed != null)
                        PausePressed(true);
                    break;
                }
            default:
                break;
        }
    }

    void CheckIfAnyKeysArePressed()
    {
        if (Input.GetKey("up"))
        {
            UpPressed(true);
        }
        if (Input.GetKey("down"))
        {
            DownPressed(true);
        }
        if (Input.GetKey("left"))
        {
            LeftPressed(true);
        }
        if (Input.GetKey("right"))
        {
            RightPressed(true);
        }
        if (Input.GetKey("a"))
        {
            APressed(true);
        }
        if (Input.GetKey("s"))
        {
            BPressed(true);
        }
        if (Input.GetKeyUp("up"))
        {
            UpPressed(false);
        }
        if (Input.GetKeyUp("down"))
        {
            DownPressed(false);
        }
        if (Input.GetKeyUp("left"))
        {
            LeftPressed(false);
        }
        if (Input.GetKeyUp("right"))
        {
            RightPressed(false);
        }
        if (Input.GetKeyUp("a"))
        {
            APressed(false);
        }
        if (Input.GetKeyUp("s"))
        {
            BPressed(false);
        }
    }
}

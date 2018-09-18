using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public delegate void TouchInputPressed();
    public static event TouchInputPressed UpPressed;
    public static event TouchInputPressed DownPressed;
    public static event TouchInputPressed LeftPressed;
    public static event TouchInputPressed RightPressed;
    public static event TouchInputPressed APressed;
    public static event TouchInputPressed BPressed;
    public static event TouchInputPressed PausePressed;

    //public LayerMask touchInputMask; Använda mig av detta?

    void Update()
    {
        if (Input.touches != null)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit2D = Physics2D.Raycast(pos, Vector2.zero);

                if (hit2D.collider != null)
                {
                    if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && !hit2D.collider.tag.Equals("Pause"))
                    {
                        WhichButton(hit2D.collider.tag);
                    }
                    else if (touch.phase == TouchPhase.Began)
                    {
                            WhichButton(hit2D.collider.tag);   
                    }
                    else
                    {
                        //Ended
                    }
                }
            }
        }
    }

    void WhichButton(string whichTag)
    {
        switch (whichTag)
        {
            case "Up":
                {
                    if (UpPressed != null)
                        UpPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "Down":
                {
                    if (DownPressed != null)
                        DownPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "Left":
                {
                    if (LeftPressed != null)
                        LeftPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "Right":
                {
                    if (RightPressed != null)
                        RightPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "A":
                {
                    if (APressed != null)
                        BPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "B":
                {
                    if (BPressed != null)
                        BPressed();
                    Debug.Log(whichTag);
                    break;
                }
            case "Pause":
                {
                    if (PausePressed != null)
                        PausePressed();
                    Debug.Log(whichTag);
                    break;
                }
            default:
                break;
        }
    }
}

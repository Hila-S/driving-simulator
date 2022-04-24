using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckDirections : WarningDisplayer
{
    Arrows arrows;
    [SerializeField] GameObject Free_Racing_Car_Blue;
    private String enter;
    private String exit;
    private const string LEFT = "left";
    private const string RIGHT = "right";
    private const string BACK = "back";
    private const string FRONT = "front";
    String direction;
    private int counterErrorDirction = 0;
    private String warningText = "Failed to listen to directions!";

    void Awake()
    {
        arrows = Free_Racing_Car_Blue.GetComponent<Arrows>();
    }


    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "crossSection")
        {
            //text.text = colText;
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            if (xAbs > yAbs && xAbs > zAbs)
            {
                // side is hit
                if (delta.x < 0)
                {
                    enter = RIGHT;
                    //warningCanvas.SetActive(true);
                }


                else
                {
                    enter = LEFT;
                }

            }
            else if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                {
                    enter = BACK;
                }
                else
                {
                    enter = FRONT;
                }

            }
            /* else
             {
                 // top/bottom is hit
                 if (delta.y > 0)
                     Debug.Log("top");
                 else
                     Debug.Log("bottom");
             }*/
            direction = arrows.GetDirection();
        }

    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "crossSection")
        {
            //text.text = colText;
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            if (xAbs > yAbs && xAbs > zAbs)
            {
                // side is hit
                if (delta.x < 0)
                {
                    exit = RIGHT;
                    //warningCanvas.SetActive(true);
                }


                else
                {
                    exit = LEFT;
                }

            }
            else if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                {
                    exit = BACK;
                }
                else
                {
                    exit = FRONT;
                }

            }
            /* else
             {
                 // top/bottom is hit
                 if (delta.y > 0)
                     Debug.Log("top");
                 else
                     Debug.Log("bottom");
             }*/
            checkDir();
        }

    }
    public void checkDir()
    {
        if (direction == "straight")
        {
            if (!((enter == FRONT && exit == BACK) || (enter == BACK && exit == FRONT)) && !((enter == RIGHT && exit == LEFT) || (enter == LEFT && exit == RIGHT)))
            {
                counterErrorDirction++;
                displayWarning(warningText);
            }
                
        }
        if (direction == "left")
        {
            if (!((enter == BACK && exit == LEFT) || (enter == LEFT && exit == FRONT)
                || (enter == FRONT && exit == RIGHT) || (enter == RIGHT && exit == BACK)))
            {
                counterErrorDirction++;
                displayWarning(warningText);
            }
        }
        if (direction == "right")
        {
            if (!((enter == BACK && exit == RIGHT) || (enter == RIGHT && exit == FRONT) || (enter == FRONT && exit == LEFT) || (enter == LEFT && exit == BACK)))
            {
                counterErrorDirction++;
                displayWarning(warningText);
            }
        }
    }
    
    public int GetNumErrorDirction()
    {
        return counterErrorDirction;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckDirections : MonoBehaviour
{
    Arrows arrows;
    [SerializeField] GameObject Free_Racing_Car_Blue;
    private String enter;
    private String exit;
    private const string LEFT = "left";
    private const string RIGHT = "right";
    private const string BACK = "back";
    private const string FRONT = "front";
    private int counterErrorDirction = 0;

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
                    Debug.Log("Right");
                    //warningCanvas.SetActive(true);
                }


                else
                {
                    enter = LEFT;
                    Debug.Log("Left");
                }

            }
            else if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                {
                    enter = BACK;
                    Debug.Log("Back");
                }
                else
                {
                    enter = FRONT;
                    Debug.Log("Front");
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
                    Debug.Log("Right");
                    //warningCanvas.SetActive(true);
                }


                else
                {
                    exit = LEFT;
                    Debug.Log("Left");
                }

            }
            else if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                {
                    exit = BACK;
                    Debug.Log("Back");
                }
                else
                {
                    exit = FRONT;
                    Debug.Log("Front");
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
        
        int direction = arrows.GetDirection();
        if (direction == 0)
        {
            if ((enter == FRONT && exit == BACK) || (enter == BACK && exit == FRONT))
                Debug.Log("bravo!");
            else if ((enter == RIGHT && exit == LEFT) || (enter == LEFT && exit == RIGHT))
                Debug.Log("bravo!");
            else
            {
                counterErrorDirction++;
                Debug.Log("error in the direction!");
            }
                
        }
        if (direction == 1)
        {
            if ((enter == BACK && exit == LEFT) || (enter == LEFT && exit == FRONT)
                || (enter == FRONT && exit == RIGHT) || (enter == RIGHT && exit == BACK))
            {
                Debug.Log("bravo!");
            }
            else
            {
                counterErrorDirction++;
                Debug.Log("error in the direction!");
            }
        }
        if (direction == 2)
        {
            if ((enter == BACK && exit == RIGHT) || (enter == RIGHT && exit == FRONT) || (enter == FRONT && exit == LEFT) || (enter == LEFT && exit == BACK))
            {
                Debug.Log("bravo!");
            }
            else
            {
                counterErrorDirction++;
                Debug.Log("error in the direction!");
            }
        }
    }
    
    public int GetNumErrorDirction()
    {
        return counterErrorDirction;
    }

}

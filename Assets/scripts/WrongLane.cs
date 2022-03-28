using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WrongLane : WarningDisplayer
{
    // private float timer = 0.0f;
    //private float howLongToDisplay = 5.0f;
    private String colText = "Wrong Lane!";

   // public Text text;
   // public GameObject warningCanvas;

    /*void Start()
    {
        warningCanvas.SetActive(false);
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > howLongToDisplay)
        {
            warningCanvas.SetActive(false);
            timer = 0.0f;
        }
    }*/

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "wrong-lane")
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
                    Debug.Log("wrong lane");
                    //warningCanvas.SetActive(true);
                    displayWarning(colText);
                }
            

                //else
                //Debug.Log("Right");
            }
            /*else if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                    Debug.Log("Back");
                else
                    Debug.Log("Front");
            }
            else
            {
                // top/bottom is hit
                if (delta.y > 0)
                    Debug.Log("top");
                else
                    Debug.Log("bottom");
            }*/
        }

    }
}

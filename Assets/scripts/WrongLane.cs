using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WrongLane : WarningDisplayer
{
    private String colText = "Wrong Lane!";
    private int counterErrorWrongLane = 0; 


    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "wrong-lane")
        {
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
                    displayWarning(colText);
                    counterErrorWrongLane++;
                }
            

            }
        }

    }

    public int GetNumErrorWrongLane()
    {
        return counterErrorWrongLane;
    }
   
}

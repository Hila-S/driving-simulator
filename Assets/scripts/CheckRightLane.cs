using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckRightLane : WarningDisplayer
{
    private String warningText = "You aren't in the right lane!";
    //private String enter;
    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "LeftLane")
        {
            //text.text = colText;
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            if (xAbs > yAbs && xAbs > zAbs)
            {
                if (delta.x >= 0)
                {
                    //enter = LEFT;
                    displayWarning(warningText);
                }

            }
        }

        if (col.gameObject.name == "RightLane")
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
                    //enter = RIGHT;
                    displayWarning(warningText);
                    //warningCanvas.SetActive(true);
                }

            }
        }

        if (col.gameObject.name == "FrontLane")
        {
            //text.text = colText;
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);

            if (zAbs > yAbs)
            {
                if (delta.z <= 0)
                {
                    //enter = FRONT;
                    displayWarning(warningText);
                }

            }

        }

        if (col.gameObject.name == "BackLane")
        {
            //text.text = colText;
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            if (zAbs > yAbs)
            {
                // front/back is hit
                if (delta.z > 0)
                {
                    //enter = BACK;
                    displayWarning(warningText);
                }

            }

        }

    }
}
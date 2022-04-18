using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoEntrySign : WarningDisplayer
{
    private String warningText = "Entrance is forbidden";

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "no entry")
        {
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            /*if (xAbs > yAbs && xAbs > zAbs)
            {
                // side is hit
                if (delta.x < 0)
                {
                    Debug.Log("Left");
                }

                else
                    Debug.Log("Right");

            }*/
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs)
            {
                // front
                if (delta.z <= 0)
                    displayWarning(warningText);
            }
            /*else
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

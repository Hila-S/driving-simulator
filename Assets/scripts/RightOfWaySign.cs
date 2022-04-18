using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RightOfWaySign : WarningDisplayer
{
    private bool slow = false;
    public Rigidbody target; // car
    private float speed = 0.0f;
    private bool enter_front = false;
    private int counterError = 0;

    private String warningText = "You did not yield";

    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
    }

    void OnTriggerEnter(Collider col)
    {
        Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
        float xAbs = Mathf.Abs(delta.x);
        float yAbs = Mathf.Abs(delta.y);
        float zAbs = Mathf.Abs(delta.z);
        if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs)
        {
            // front
            if (delta.z <= 0)
            {
                enter_front = true;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "yield sign" && enter_front)
        {
            if (speed < 20)
            {
                slow = true;
            }

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "yield sign" && enter_front)
        {
            if (!slow)
            {
                displayWarning(warningText);
                counterError++;
            }
            slow = false;
            enter_front = false;
        }
    }

    public int GetNumErrorStopSign()
    {
        return counterError;
    }
}

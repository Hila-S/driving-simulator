using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StopSign : WarningDisplayer
{
    private bool stopped = false;
    public Rigidbody target; // car
    private float speed = 0.0f;
    private int counterError = 0;

    private String warningText = "You did not stop at the stop sign";

    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "StopSignLine")
        {
            if (speed < 0.1) {
                stopped = true;
            }

        }
    }
    void OnTriggerExit(Collider col)
    {
        // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
        Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
        float xAbs = Mathf.Abs(delta.x);
        float yAbs = Mathf.Abs(delta.y);
        float zAbs = Mathf.Abs(delta.z);
        if (col.gameObject.name == "StopSignLine")
        {
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs)
            {
                if (delta.z > 0 && !stopped)
                {
                    displayWarning(warningText);
                    counterError++;
                }
            }
            stopped = false;
        }

    }
    public int GetNumErrorStopSign()
    {
        return counterError;
    }
}

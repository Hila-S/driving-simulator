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
        if (col.gameObject.name == "StopSignLine")
        {
            if (!stopped)
            {
                displayWarning(warningText);
                counterError++;
            }
            stopped = false;
        }

    }
    public int GetNumErrorStopSign()
    {
        return counterError;
    }
}

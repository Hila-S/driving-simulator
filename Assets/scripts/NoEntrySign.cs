using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoEntrySign : WarningDisplayer
{
    private String warningText = "Entrance is forbidden";
    private int errorCounter = 0;

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "no entry")
        {
            // Only works if not rotated or scaled: Vector3 delta = collider.gameObject.transform.position - gameObject.transform.position;
            Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
            float xAbs = Mathf.Abs(delta.x);
            float yAbs = Mathf.Abs(delta.y);
            float zAbs = Mathf.Abs(delta.z);
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs)
            {
                // front
                if (delta.z <= 0)
                {
                    displayWarning(warningText);
                    errorCounter++;
                }
            }
        }

    }

    public int GetNumErrors()
    {
        return errorCounter;
    }
}

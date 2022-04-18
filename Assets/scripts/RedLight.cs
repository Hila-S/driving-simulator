using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RedLight : WarningDisplayer
{
    public GameObject red;
    public Material red_mat_on;

    private String warningText = "You have run a red light!";
    private int countrErrorRedLight = 0;

    void OnTriggerEnter(Collider col)
    {
        Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
        float xAbs = Mathf.Abs(delta.x);
        float yAbs = Mathf.Abs(delta.y);
        float zAbs = Mathf.Abs(delta.z);

        if (col.gameObject.name == "LightStopLine" && red.GetComponent<MeshRenderer>().material.name.Substring(0, 12) == red_mat_on.name)
        {
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs)
            {
                // front
                if (delta.z <= 0)
                {

                    displayWarning(warningText);
                    countrErrorRedLight++;
                }
            }
        }
    }

    public int GetNumErrorRedLight()
    {
        return countrErrorRedLight;
    }

}

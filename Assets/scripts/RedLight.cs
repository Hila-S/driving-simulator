using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RedLight : WarningDisplayer
{
    public GameObject red;
    public Material red_mat_on;

    private String colText = "You have run a red light!";
    private int countrErrorRedLight = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "LightStopLine" && red.GetComponent<MeshRenderer>().material.name.Substring(0, 12) == red_mat_on.name)
        {
            displayWarning(colText);
            countrErrorRedLight++;
        }
    }

    public int GetNumErrorRedLight()
    {
        return countrErrorRedLight;
    }

}

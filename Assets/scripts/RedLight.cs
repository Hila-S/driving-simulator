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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "LightStopLine" && red.GetComponent<MeshRenderer>().material.name.Substring(0, 12) == red_mat_on.name)
        {
            displayWarning(colText);
        }
    }
}

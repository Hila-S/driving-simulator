using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SeparationLine : WarningDisplayer
{
    private int counterErrorSeparationLine = 0;
    private String warningText = "You went on a dividing line";

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "dividing line")
        {
            counterErrorSeparationLine++;
            displayWarning(warningText);
        }
           
    }

    public int GetNumErrorSeparationLine()
    {
        return counterErrorSeparationLine;
    }
}

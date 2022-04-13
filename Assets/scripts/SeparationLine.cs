using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SeparationLine : MonoBehaviour
{
    private int counterErrorSeparationLine = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SeparationLine")
        {
            Debug.Log("collisionon SeparationLine");
            counterErrorSeparationLine++;
        }
           
    }

    public int GetNumErrorSeparationLine()
    {
        return counterErrorSeparationLine;
    }
}

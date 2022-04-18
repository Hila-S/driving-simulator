using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class CarCollision : WarningDisplayer
{
    private String warningText = "You have collided with the sidewalk!";
    private int counterCollisions = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "sidewalk")
        {
            warningText = "You have collided with the sidewalk!";
            displayWarning(warningText);
            counterCollisions++;
        }
        if (col.gameObject.name == "separation line")
        {
            warningText = "You have collided with the separation line!";
            displayWarning(warningText);
            counterCollisions++;
        }
           
    }

    public int GetNumHumanCollisions()
    {
        return counterCollisions;
    }
}

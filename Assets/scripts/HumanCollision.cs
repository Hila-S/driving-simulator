using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class HumanCollision : WarningDisplayer
{
    private String warningText = "Oh no! You hit a person!";
    private int counterCollisions = 0;
    private String[] names = { "Remy1", "Remy2", "Remy3", "Remy4", "Remy5", "Sophie1", "Sophie2", "Sophie3",
        "Sophie4", "Sophie5", "Bryce1", "Bryce2", "Bryce3", "Bryce4", "Bryce5", "Elizabeth1",
        "Elizabeth2", "Elizabeth3", "Elizabeth4", "Elizabeth5", "Josh1", "Josh2", "Josh3", "Josh4", "Josh5"};

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        //if (collision.gameObject.name == "person")
        if (names.Contains(collision.gameObject.name))
        {
            counterCollisions++;
            displayWarning(warningText);
        }
    }
    
    public int GetNumHumanCollisions()
    {
        return counterCollisions;
    }
}


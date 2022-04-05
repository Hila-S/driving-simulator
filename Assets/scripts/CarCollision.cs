using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/*public class CarCollision : WarningDisplayer
{
    private String colText = "You have collided with the sidewalk!";


    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Road_1_line" || collision.gameObject.name == "Crossroads_1_lines_walk" ||
            collision.gameObject.name == "Crossroads_1_lines_circ" || collision.gameObject.name == "Road_1_line_turn")
        {
            text.text = colText;
            //If the GameObject's name matches the one you suggest, output this message in the console
            displayWarning(colText);
        }
    }
}*/

public class CarCollision : MonoBehaviour
{
    //private String colText = "You have collided with the sidewalk!";


    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Road_1_line" || collision.gameObject.name == "Crossroads_1_lines_walk" ||
            collision.gameObject.name == "Crossroads_1_lines_circ" || collision.gameObject.name == "Road_1_line_turn" ||
            collision.gameObject.name == "Sidewalk_08" || collision.gameObject.name == "Sideway 8 prefab (4)")
        {
            Debug.Log("collision");
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "sidewalk")
            Debug.Log("collision");
    }
}

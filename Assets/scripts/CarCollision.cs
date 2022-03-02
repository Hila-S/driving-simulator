using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Road_1_line" || collision.gameObject.name == "Crossroads_1_lines_walk" ||
            collision.gameObject.name == "Crossroads_1_lines_circ" || collision.gameObject.name == "Road_1_line_turn" ||
            collision.gameObject.name == "Traffic_pot prefab")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something else here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}

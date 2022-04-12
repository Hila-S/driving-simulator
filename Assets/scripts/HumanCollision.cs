using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HumanCollision : MonoBehaviour
{
    private int counterCollisions = 0;
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Michelle")
        {
            counterCollisions++;
            Debug.Log("collision on human");
        }
    }
    /*
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Michelle")
            counter++;
            Debug.Log("collisionon human");
    }
    */
    public int GetNumHumanCollisions()
    {
        return counterCollisions;
    }
}


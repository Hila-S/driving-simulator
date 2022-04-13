using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpeed : MonoBehaviour
{
    public Rigidbody target; // car
    private float speed = 0.0f;
    private int counterErrorSpeed = 0;
    bool aboveSpeed = false;

    // Update is called once per frame
    void Update()
    {
        speed = target.velocity.magnitude * 3.6f * 3.5f;
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Speed50" && speed > 20 && aboveSpeed == false )
        {
            aboveSpeed = true;
            Debug.Log("too fast");
            counterErrorSpeed++;
        }
    }
    void OnTriggerExit(Collider col) //update the bool aboveSpeed to be false
    {
        aboveSpeed = false;
    }


    public int GetNumErrorSpeed()
    {
        return counterErrorSpeed;
    }
}

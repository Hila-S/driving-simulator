using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckSpeed : WarningDisplayer
{
    public Rigidbody target; // car
    private float speed = 0.0f;
    private int counterErrorSpeed = 0;
    bool aboveSpeed = false;
    int speedLimit = 0;

    private String warningText = "You have gone above the speed limit";
    void Start()
    {
        string speedString = "50"; // firebase
        Int32.TryParse(speedString, out speedLimit);
    }

    // Update is called once per frame
    void Update()
    {
        speed = target.velocity.magnitude * 3.6f * 2.5f;
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.gameObject.name == "directions-rls" || col.gameObject.name == "directions-rl" || col.gameObject.name == "directions-rs" 
            || col.gameObject.name == "directions-ls" || col.gameObject.name == "directions-r" || col.gameObject.name == "directions-l"
            || col.gameObject.name == "directions-s") && speed > speedLimit && aboveSpeed == false )
        {
            aboveSpeed = true;
            displayWarning(warningText);
            counterErrorSpeed++;
        }
        if ((col.gameObject.name == "directions-rls-70" || col.gameObject.name == "directions-rl-70" || col.gameObject.name == "directions-rs-70"
            || col.gameObject.name == "directions-ls-70" || col.gameObject.name == "directions-r-70" || col.gameObject.name == "directions-l-70"
            || col.gameObject.name == "directions-s-70") && speed > 70 && aboveSpeed == false)
        {
            aboveSpeed = true;
            displayWarning(warningText);
            counterErrorSpeed++;
        }
        if ((col.gameObject.name == "directions-rls-30" || col.gameObject.name == "directions-rl-30" || col.gameObject.name == "directions-rs-30"
            || col.gameObject.name == "directions-ls-30" || col.gameObject.name == "directions-r-30" || col.gameObject.name == "directions-l-30"
            || col.gameObject.name == "directions-s-30") && speed > 30 && aboveSpeed == false)
        {
            aboveSpeed = true;
            displayWarning(warningText);
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

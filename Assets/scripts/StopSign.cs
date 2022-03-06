using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private bool stopped = false;
    public Rigidbody target; // car
    private float speed = 0.0f;

    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f * 3.5f;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "StopSignLine")
        {
            if (speed < 0.1) {
                stopped = true;
            }

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "StopSignLine")
        {
            if (!stopped)
                Debug.Log("didnt stop");
            stopped = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpeed : MonoBehaviour
{
    public Rigidbody target; // car
    private float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        speed = target.velocity.magnitude * 3.6f * 3.5f;
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Speed50" && speed > 20)
        {
            Debug.Log("too fast");
        }
    }
}

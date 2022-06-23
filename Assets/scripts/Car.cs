using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;
    public float speed = 0;
    public float maxSpeed = 20;
    public float acceleration = 9;
    public float deceleration = 9;


    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    void FixedUpdate()
    {
        /*have the car move according to the arrow keys of the user*/
        if (Input.GetKey(KeyCode.RightShift))
            speed += 1;
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(backward * speed * Time.deltaTime);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceTravelled : MonoBehaviour
{
    float distanceTravelled = 0;
    Vector3 lastPosition;

    private string toggle;
    private string distanceString = "";

    void Start()
    {
        lastPosition = transform.position;

        toggle = "time"; // firebase
        if (toggle == "distance")
        {
            distanceString = "1"; // firbase
        }
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        distanceTravelled *= 2.5f;
        lastPosition = transform.position;

        if (toggle == "distance")
        {
            float distance = float.Parse(distanceString);
            if (distanceTravelled > distance * 1000)
            {
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}

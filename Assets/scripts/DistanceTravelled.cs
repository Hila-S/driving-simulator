using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceTravelled : MonoBehaviour
{
    float distanceTravelled = 0;
    Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition) * 3.5f;
        lastPosition = transform.position;
        if (distanceTravelled > 100)
            SceneManager.LoadScene("EndGame");
    }
}

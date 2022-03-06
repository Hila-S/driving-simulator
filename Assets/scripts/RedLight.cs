using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    public GameObject red;
    public Material red_mat_on;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "LightStopLine" && red.GetComponent<MeshRenderer>().material.name.Substring(0, 12) == red_mat_on.name)
        {
            Debug.Log("stop");
        }
    }
}

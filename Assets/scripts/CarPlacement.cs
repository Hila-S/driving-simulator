using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.SceneManagement;

public class CarPlacement : MonoBehaviour
{

    private int rInt;
    // private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rInt = Range(0, 4); //for ints
        // string currentScene = SceneManager.GetActiveScene().name;
        if (rInt == 0)
        {
            transform.position = new Vector3(106f, 0.11f, 532f);
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (rInt == 1)
        {
            transform.position = new Vector3(186f, 0.11f, 823f);
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (rInt == 2)
        {
            transform.position = new Vector3(448f, 0.11f, 403f);
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (rInt == 3)
        {
            transform.position = new Vector3(489.7f, 0.11f, 164f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
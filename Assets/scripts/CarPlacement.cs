using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class CarPlacement : MonoBehaviour
{

    private int rInt;

    // Start is called before the first frame update
    void Start()
    {
        rInt = Range(0, 3); //for ints
        if (rInt == 0)
            transform.position = new Vector3(106f, 0.11f, 532f);
        if (rInt == 1)
            transform.position = new Vector3(186f, 0.11f, 823f);
        if (rInt == 2)
            transform.position = new Vector3(448f, 0.11f, 403f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

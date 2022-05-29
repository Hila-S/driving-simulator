using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool counterDownDone = false;
    public GameObject countdownImage;

    // Update is called once per frame
    void Update()
    {
        if (counterDownDone)
            countdownImage.SetActive(false);
    }
}

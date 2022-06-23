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
        //once the countdown (3,2,1) is done we deactivate the 3,2,1 images 
        if (counterDownDone)
            countdownImage.SetActive(false);
    }
}

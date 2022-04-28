using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImageChanger : MonoBehaviour
{
    public Sprite onImage;
    public Sprite offImage;
    public Toggle toggle;

    public void Update()
    {
        if (toggle.isOn)
        {
            toggle.GetComponent<Image>().sprite = onImage;
        }
        else
        {
            toggle.GetComponent<Image>().sprite = offImage;
        }
           
     }
}

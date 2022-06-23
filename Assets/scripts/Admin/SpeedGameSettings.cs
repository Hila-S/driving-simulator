using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGameSettings : MonoBehaviour
{
    public Text inputFieldText;

    //gets the input for the speed limit that the admin enters
    public string get_input()
    {
        string input_text = inputFieldText.text;
        return input_text;
    }
}

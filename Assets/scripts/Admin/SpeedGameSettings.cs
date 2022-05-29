using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGameSettings : MonoBehaviour
{
    public Text inputFieldText;

    public string get_input()
    {
        string input_text = inputFieldText.text;
        return input_text;
    }
}

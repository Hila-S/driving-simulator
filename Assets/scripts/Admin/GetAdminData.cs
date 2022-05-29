using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAdminData : MonoBehaviour
{

    EndGameSettings endGame;
    SpeedGameSettings speedGame;
    ToggleGroup toggleGroup;
    InputField inputFieldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
        inputFieldSpeed = GameObject.Find("InputFieldSpeed").GetComponent<InputField>();
        endGame = toggleGroup.GetComponent<EndGameSettings>();
        speedGame = inputFieldSpeed.GetComponent<SpeedGameSettings>();
    }
    public string get_end_input()
    {
        string end_input = endGame.get_input();
        return end_input;
    }
    public string get_speed_input()
    {
        inputFieldSpeed = GameObject.Find("InputFieldSpeed").GetComponent<InputField>();
        speedGame = inputFieldSpeed.GetComponent<SpeedGameSettings>();
        string speed_input = speedGame.get_input();
        return speed_input;
    }
    public string get_toggle()
    {
        toggleGroup = GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
        endGame = toggleGroup.GetComponent<EndGameSettings>();
        string toggle = endGame.get_toggle();
        return toggle;
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndGameSettings : MonoBehaviour
{
    public Text input;
    public Text inputFieldText;
    public InputField inputSpeed;
    public InputField inputEnd;

    ToggleGroup toggleGroup;
    Toggle time_toggle;
    Toggle distance_toggle;
    Toggle commands_toggle;

    string end_input;

    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        time_toggle = transform.Find("time").GetComponent<Toggle>();
        distance_toggle = transform.Find("distance").GetComponent<Toggle>();
        commands_toggle = transform.Find("commands").GetComponent<Toggle>();

        // firebase
        string toggle = "time";
        string speed_input = "50";

        inputSpeed.GetComponent<InputField>().placeholder.GetComponent<Text>().text = speed_input;

        if (toggle == "time")
        {
            time_toggle.isOn = true;
            input.text = "Enter a time in minutes:";
            end_input = "10"; // firebase
            inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;

        } else if (toggle == "distance")
        {
            distance_toggle.isOn = true;
            input.text = "Enter a distance in km:";
            end_input = "5"; // firebase
            inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
        } else
        {
            commands_toggle.isOn = true;
            input.text = "Enter a number of commands:";
            end_input = "3"; // firebase
            inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
        }

        time_toggle.onValueChanged.AddListener(delegate {
            if (time_toggle.isOn)
            {
                time_is_on();
            }
        });
        distance_toggle.onValueChanged.AddListener(delegate {
            if (distance_toggle.isOn)
            {
                distance_is_on();
            }
        });
        commands_toggle.onValueChanged.AddListener(delegate {
            if (commands_toggle.isOn)
            {
                commands_is_on();
            }
        });
    }

    void time_is_on()
    {
        input.text = "Enter a time in minutes:";
        end_input = "10"; // firebase
        inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
    }
    void distance_is_on()
    {
        input.text = "Enter a distance in km:";
        end_input = "5"; // firebase
        inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
    }
    void commands_is_on()
    {
        input.text = "Enter a number of commands:";
        end_input = "8"; // firebase
        inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
    }

    public Toggle currentSelection
    {
        get { return toggleGroup.ActiveToggles().FirstOrDefault(); }
    }

    public string get_toggle()
    {
        return currentSelection.name;
    }
    public string get_input()
    {
        string input_text = inputFieldText.text;
        return input_text;
    }
}

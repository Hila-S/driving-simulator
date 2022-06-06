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
    string time_input = "";
    string distance_input = "";
    string commands_input = "";

    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        time_toggle = transform.Find("time").GetComponent<Toggle>();
        distance_toggle = transform.Find("distance").GetComponent<Toggle>();
        commands_toggle = transform.Find("commands").GetComponent<Toggle>();

        string toggle = "";
        string speed_input = "";
        
        // firebase
        GameObject adminFirebaseObj;
        AdminFirebase adminFirebase;
        adminFirebaseObj = GameObject.Find("AdminFirebase");
        if (adminFirebaseObj != null)
        {
            adminFirebase = adminFirebaseObj.GetComponent<AdminFirebase>();
            toggle = adminFirebase.GetState(); // firebase - state
            speed_input = adminFirebase.GetSpeed(); // firebase - get the spped
            time_input = adminFirebase.GetNum("time");
            distance_input = adminFirebase.GetNum("distance"); // firbase - the distance
            commands_input = adminFirebase.GetNum("commands");
 
        }
        //string toggle = "time"; // get staee
        //string speed_input = "50";// get_speed

        inputSpeed.GetComponent<InputField>().placeholder.GetComponent<Text>().text = speed_input;

        if (toggle == "time")
        {
            time_toggle.isOn = true;
            input.text = "Enter a time in minutes:";
            end_input = time_input; // firebase - get the num time
            inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;

        } else if (toggle == "distance")
        {
            distance_toggle.isOn = true;
            input.text = "Enter a distance in km:";
            end_input = distance_input; // firebase - get the num distance
            inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
        } else
        {
            commands_toggle.isOn = true;
            input.text = "Enter a number of commands:";
            end_input = commands_input; // firebase - get the num command
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
        end_input = time_input; // firebase - time
        inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
    }
    void distance_is_on()
    {
        input.text = "Enter a distance in km:";
        end_input = distance_input; // firebase - distance
        inputEnd.GetComponent<InputField>().placeholder.GetComponent<Text>().text = end_input;
    }
    void commands_is_on()
    {
        input.text = "Enter a number of commands:";
        end_input = commands_input; // firebase - command
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

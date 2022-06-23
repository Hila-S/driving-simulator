using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;
using System;
using UnityEngine.SceneManagement;

public class Arrows : MonoBehaviour
{
    public Image direction_img;
    public Sprite up_arrow;
    public Sprite right_arrow;
    public Sprite left_arrow;

    private int rInt;
    private String direction;

    private const string LEFT = "left";
    private const string RIGHT = "right";
    private const string STRAIGHT = "straight";

    private string toggle;
    private string numOfCommands = "4";

    private int commandCounter = 0;

    [SerializeField] GameObject audioSource;
    AudioPlayerDirections audioPlayer;

    private GameManagerScript GMS;
    private bool isFirst;

    void Start()
    {

        direction_img.enabled = false;
        audioPlayer = audioSource.GetComponent<AudioPlayerDirections>();

        GameObject adminFirebaseObj;
        AdminFirebase adminFirebase;
        adminFirebaseObj = GameObject.Find("AdminFirebase");
        if (adminFirebaseObj != null)
        {
            adminFirebase = adminFirebaseObj.GetComponent<AdminFirebase>();
            toggle = adminFirebase.GetState(); // firebase - state
            if (toggle == "commands")
                numOfCommands = adminFirebase.GetNum("commands"); // firbase - the num of the commands
        }
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        isFirst = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (GMS.counterDownDone)
        {
            direction_img.enabled = true;
            if (col.gameObject.name == "directions-rls" || col.gameObject.name == "directions-rls-70" || col.gameObject.name == "directions-rls-30")
            {
                rInt = Range(0, 3); //for ints
                if (rInt == 0)
                {
                    direction = STRAIGHT;
                    direction_img.GetComponent<Image>().sprite = up_arrow;
                }
                if (rInt == 1)
                {
                    direction = LEFT;
                    direction_img.GetComponent<Image>().sprite = left_arrow;
                }
                if (rInt == 2)
                {
                    direction = RIGHT;
                    direction_img.GetComponent<Image>().sprite = right_arrow;
                }
                commandCounter++;
                audioPlayer.playSound(direction);
            }
            if (col.gameObject.name == "directions-rl" || col.gameObject.name == "directions-rl-70" || col.gameObject.name == "directions-rl-30")
            {
                rInt = Range(1, 3); //for ints
                if (rInt == 1)
                {
                    direction = LEFT;
                    direction_img.GetComponent<Image>().sprite = left_arrow;
                }
                if (rInt == 2)
                {
                    direction = RIGHT;
                    direction_img.GetComponent<Image>().sprite = right_arrow;
                }
                commandCounter++;
                audioPlayer.playSound(direction);
            }
            if (col.gameObject.name == "directions-rs" || col.gameObject.name == "directions-rs-70" || col.gameObject.name == "directions-rs-30")
            {
                rInt = Range(1, 3); //for ints
                if (rInt == 1)
                {
                    direction = STRAIGHT;
                    direction_img.GetComponent<Image>().sprite = up_arrow;
                }
                if (rInt == 2)
                {
                    direction = RIGHT;
                    direction_img.GetComponent<Image>().sprite = right_arrow;
                }
                commandCounter++;
                audioPlayer.playSound(direction);
            }
            if (col.gameObject.name == "directions-ls" || col.gameObject.name == "directions-ls-70" || col.gameObject.name == "directions-ls-30")
            {
                rInt = Range(1, 3); //for ints
                if (rInt == 1)
                {
                    direction = STRAIGHT;
                    direction_img.GetComponent<Image>().sprite = up_arrow;
                }
                if (rInt == 2)
                {
                    direction = LEFT;
                    direction_img.GetComponent<Image>().sprite = left_arrow;
                }
                commandCounter++;
                audioPlayer.playSound(direction);
            }
            if (col.gameObject.name == "directions-l" || col.gameObject.name == "directions-l-70" || col.gameObject.name == "directions-l-30")
            {
                direction = LEFT;
                direction_img.GetComponent<Image>().sprite = left_arrow;
                commandCounter++;
            }
            if (col.gameObject.name == "directions-r" || col.gameObject.name == "directions-r-70" || col.gameObject.name == "directions-r-30")
            {
                direction = RIGHT;
                direction_img.GetComponent<Image>().sprite = right_arrow;
                commandCounter++;
                audioPlayer.playSound(direction);
            }
            if (col.gameObject.name == "directions-s" || col.gameObject.name == "directions-s-70" || col.gameObject.name == "directions-s-30")
            {
                direction = STRAIGHT;
                direction_img.GetComponent<Image>().sprite = up_arrow;
                commandCounter++;
            }

            if (toggle == "commands")
            {
                int commandsNum = 0;
                Int32.TryParse(numOfCommands, out commandsNum);
                if (commandCounter > commandsNum)
                {
                    SceneManager.LoadScene("EndGame");
                }
            }
        }

        if (col.gameObject.name == "rls-first" && isFirst)
        {
            rInt = Range(0, 3); //for ints
            if (rInt == 0)
            {
                direction = STRAIGHT;
                direction_img.GetComponent<Image>().sprite = up_arrow;
            }
            if (rInt == 1)
            {
                direction = LEFT;
                direction_img.GetComponent<Image>().sprite = left_arrow;
            }
            if (rInt == 2)
            {
                direction = RIGHT;
                direction_img.GetComponent<Image>().sprite = right_arrow;
            }
            commandCounter++;
            audioPlayer.playSound(direction);

            isFirst = false;
        }
        if (col.gameObject.name == "rs-first" && isFirst)
        {
            rInt = Range(1, 3); //for ints
            if (rInt == 1)
            {
                direction = STRAIGHT;
                direction_img.GetComponent<Image>().sprite = up_arrow;
            }
            if (rInt == 2)
            {
                direction = RIGHT;
                direction_img.GetComponent<Image>().sprite = right_arrow;
            }
            commandCounter++;
            audioPlayer.playSound(direction);
            isFirst = false;
        }
        if (col.gameObject.name == "rl-first" && isFirst)
        {
            rInt = Range(1, 3); //for ints
            if (rInt == 1)
            {
                direction = LEFT;
                direction_img.GetComponent<Image>().sprite = left_arrow;
            }
            if (rInt == 2)
            {
                direction = RIGHT;
                direction_img.GetComponent<Image>().sprite = right_arrow;
            }
            commandCounter++;
            audioPlayer.playSound(direction);
            isFirst = false;
        }

    }
    public String GetDirection()
    {
        return direction;
    }
}

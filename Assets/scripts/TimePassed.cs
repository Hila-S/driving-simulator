using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//for when the admin chooses that the game should end based on amount of time
public class TimePassed : MonoBehaviour
{
    float timer = 0;
    private string toggle;
    private string timeString = "";

    // Start is called before the first frame update
    void Start()
    {
        GameObject adminFirebaseObj;
        AdminFirebase adminFirebase;
        adminFirebaseObj = GameObject.Find("AdminFirebase");
        if (adminFirebaseObj != null)
        {
            adminFirebase = adminFirebaseObj.GetComponent<AdminFirebase>();
            toggle = adminFirebase.GetState(); // firebase - state
            if (toggle == "time")
                timeString = adminFirebase.GetNum("time"); // firebase - the time
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (toggle == "time")
        {
            float time = float.Parse(timeString);
            if (timer > time * 60)
            {
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}

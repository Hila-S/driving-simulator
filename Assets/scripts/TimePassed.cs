using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimePassed : MonoBehaviour
{
    float timer = 0;
    private string toggle;
    private string timeString = "";

    // Start is called before the first frame update
    void Start()
    {
        toggle = "time"; // firebase
        if (toggle == "time")
        {
            timeString = "1"; // firbase
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

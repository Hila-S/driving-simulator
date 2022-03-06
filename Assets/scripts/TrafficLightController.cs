using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject red;
    public Material red_mat_off;
    public Material red_mat_on;

    public GameObject yellow;
    public Material yellow_mat_off;
    public Material yellow_mat_on;

    public GameObject green;
    public Material green_mat_off;
    public Material green_mat_on;


    private float timer = 0.0f;
    private float timer_green = 7f;
    private float timer_red = 5f;
    private float timer_yellow = 1f;

    private bool wasRed = true;
    private bool y = false;
    private bool g = false;
    private bool r = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timer_red && r)
        {
            red.GetComponent<MeshRenderer>().material = red_mat_off;
            yellow.GetComponent<MeshRenderer>().material = yellow_mat_on;
            timer = 0f;
            wasRed = true;
            r = false;
            y = true;
        }
        if (timer > timer_green && g)
        {
            green.GetComponent<MeshRenderer>().material = green_mat_off;
            yellow.GetComponent<MeshRenderer>().material = yellow_mat_on;
            timer = 0f;
            wasRed = false;
            g = false;
            y = true;
        }
        if (timer > timer_yellow && y)
        {
            if (wasRed == true)
            {
                green.GetComponent<MeshRenderer>().material = green_mat_on;
                g = true;
            }
            else
            {
                red.GetComponent<MeshRenderer>().material = red_mat_on;
                r = true;
            }
            yellow.GetComponent<MeshRenderer>().material = yellow_mat_off;
            y = false;
            timer = 0f;
        }
    }
}

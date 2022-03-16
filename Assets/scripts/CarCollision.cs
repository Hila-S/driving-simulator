using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarCollision : MonoBehaviour
{
    private float timer = 0.0f;
    private float howLongToDisplay = 5.0f;
    private String colText = "You have collided with the sidewalk!";

    public Text text;
    public GameObject warningCanvas;

    void Start()
    {
        warningCanvas.SetActive(false);
        text.text = colText;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > howLongToDisplay)
        {
            warningCanvas.SetActive(false);
            timer = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Road_1_line" || collision.gameObject.name == "Crossroads_1_lines_walk" ||
            collision.gameObject.name == "Crossroads_1_lines_circ" || collision.gameObject.name == "Road_1_line_turn")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //Debug.Log("Do something else here");
            warningCanvas.SetActive(true);
        }
    }
}

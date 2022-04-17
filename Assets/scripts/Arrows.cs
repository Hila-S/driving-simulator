using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;
using System;

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

    void Start()
    {
        direction_img.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        direction_img.enabled = true;
        if (col.gameObject.name == "directions-rls")
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
        }
        if (col.gameObject.name == "directions-rl")
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
        }
        if (col.gameObject.name == "directions-rs")
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
        }
        if (col.gameObject.name == "directions-ls")
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
        }
        if (col.gameObject.name == "directions-l")
        {
                direction = LEFT;
                direction_img.GetComponent<Image>().sprite = left_arrow;
        }
        if (col.gameObject.name == "directions-r")
        {
            direction = RIGHT;
            direction_img.GetComponent<Image>().sprite = right_arrow;
        }
        if (col.gameObject.name == "directions-s")
        {
            direction = STRAIGHT;
            direction_img.GetComponent<Image>().sprite = up_arrow;
        }

    }
    public String GetDirection()
    {
        return direction;
    }
}

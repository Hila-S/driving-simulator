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
        }
        if (col.gameObject.name == "directions-l" || col.gameObject.name == "directions-l-70" || col.gameObject.name == "directions-l-30")
        {
                direction = LEFT;
                direction_img.GetComponent<Image>().sprite = left_arrow;
        }
        if (col.gameObject.name == "directions-r" || col.gameObject.name == "directions-r-70" || col.gameObject.name == "directions-r-30")
        {
            direction = RIGHT;
            direction_img.GetComponent<Image>().sprite = right_arrow;
        }
        if (col.gameObject.name == "directions-s" || col.gameObject.name == "directions-s-70" || col.gameObject.name == "directions-s-30")
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

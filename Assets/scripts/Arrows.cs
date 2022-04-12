using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;

public class Arrows : MonoBehaviour
{
    public GameObject direction_img;
    public Sprite up_arrow;
    public Sprite right_arrow;
    public Sprite left_arrow;
    public Sprite u_turn_arrow;
    private int rInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "directions-rls")
        {
            rInt = Range(0, 2); //for ints
            if (rInt == 0)
            {
                direction_img.GetComponent<Image>().sprite = up_arrow;
            }
            if (rInt == 1)
            {
                direction_img.GetComponent<Image>().sprite = left_arrow;
            }
            if (rInt == 2)
            {
                direction_img.GetComponent<Image>().sprite = right_arrow;
            }
        }
        if (col.gameObject.name == "directions-rlsu")
        {
            rInt = Range(0, 3); //for ints
            if (rInt == 0)
            {
                direction_img.GetComponent<Image>().sprite = up_arrow;
            }
            if (rInt == 1)
            {
                direction_img.GetComponent<Image>().sprite = left_arrow;
            }
            if (rInt == 2)
            {
                direction_img.GetComponent<Image>().sprite = right_arrow;
            }
            if (rInt == 3)
            {
                direction_img.GetComponent<Image>().sprite = u_turn_arrow;
            }
        }

    }
    public int GetDirection()
    {
        return rInt;
    }
}

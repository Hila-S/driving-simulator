using UnityEngine;

public class lightController : MonoBehaviour
{
    public Light lt_r;
    public Light lt_y;
    public Light lt_g;

    private float timer = 0.0f;
    private float timer_green = 7f;
    private float timer_red = 5f;
    private float timer_yellow = 1f;

    private Color red = Color.red;
    private Color yellow = Color.yellow;
    private Color green = Color.green;

    private bool wasRed = true;
    private bool y = false;
    private bool g = false;
    private bool r = true;

    void Start()
    {
        //lt = GetComponent<Light>();
    }

    // Darken the light completely over a period of 2 seconds.
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timer_red && r)
        {
            lt_r.color = Color.white;
            lt_y.color = yellow;
            timer = 0f;
            wasRed = true;
            r = false;
            y = true;
        }
        if (timer > timer_green && g)
        {
            lt_g.color = Color.white;
            lt_y.color = yellow;
            timer = 0f;
            wasRed = false;
            g = false;
            y = true;
        }
        if (timer > timer_yellow && y)
        {
            lt_y.color = Color.white;
            y = false;
            if (wasRed == true)
            {
                lt_g.color = green;
                g = true;
            }
            else
            {
                lt_r.color = red;
                r = true;
            }
            timer = 0f;
        }
    }
}
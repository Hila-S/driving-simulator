using UnityEngine;

public class SetCountdown : MonoBehaviour
{
    private GameManagerScript GMS;

    //called by the countdown animation
    public void setCountdownNow()
    {
        //once the countdown ends we change the bool to true
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.counterDownDone = true;
    }
}

using UnityEngine;

public class SetCountdown : MonoBehaviour
{
    private GameManagerScript GMS;

    public void setCountdownNow()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.counterDownDone = true;
    }
}

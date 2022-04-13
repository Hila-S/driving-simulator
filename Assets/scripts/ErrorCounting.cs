using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCounting : MonoBehaviour
{
    [SerializeField] GameObject Free_Racing_Car_Blue;
    CheckDirections checkDirections;
    HumanCollision humanCollision;
    CarCollision carCollision;
    RedLight redLight;
    CheckSpeed checkSpeed;
    WrongLane wrongLane;
    SeparationLine separationLine;
    StopSign stopSign;

    private int counterErrorDirections = 0;
    int counterHumanCollisions = 0;
    int counterCollisions = 0;
    int counterErrorRedLight = 0;
    int counterErrorSpeed = 0;
    int counterErrorWrongLane = 0;
    int counterErrorSeparationLine = 0;
    int counterErrorStopSign = 0;


    void Awake()
    {
        DontDestroyOnLoad(this);
        checkDirections = Free_Racing_Car_Blue.GetComponent<CheckDirections>();
        humanCollision = Free_Racing_Car_Blue.GetComponent<HumanCollision>();
        carCollision = Free_Racing_Car_Blue.GetComponent<CarCollision>();
        redLight = Free_Racing_Car_Blue.GetComponent<RedLight>();
        checkSpeed = Free_Racing_Car_Blue.GetComponent<CheckSpeed>();
        wrongLane = Free_Racing_Car_Blue.GetComponent<WrongLane>();
        separationLine = Free_Racing_Car_Blue.GetComponent<SeparationLine>();
        stopSign = Free_Racing_Car_Blue.GetComponent<StopSign>();
    }

    // Update is called once per frame
    void Update()
    {
        counterErrorDirections = checkDirections.GetNumErrorDirction();
        counterHumanCollisions = humanCollision.GetNumHumanCollisions();
        counterCollisions = carCollision.GetNumHumanCollisions();
        counterErrorRedLight = redLight.GetNumErrorRedLight();
        counterErrorSpeed = checkSpeed.GetNumErrorSpeed();
        counterErrorWrongLane = wrongLane.GetNumErrorWrongLane();
        counterErrorSeparationLine = separationLine.GetNumErrorSeparationLine();
        counterErrorStopSign = stopSign.GetNumErrorStopSign();

        /*
        if(counterErrorDirections>=1)
            Debug.Log("counterErrorDirections:" + counterErrorDirections);
        if (counterErrorSpeed >= 1)
        {
            Debug.Log("counterErrorSpeed:" + counterErrorSpeed);
        }
        */
        if (counterErrorSeparationLine >= 1)
        {
            Debug.Log("counterErrorSeparationLine:" + counterErrorSeparationLine);
        }
    }

    public int GetErrorDirections()
    {
        return counterErrorDirections;
    }

    public int GetNumCollisions()
    {
        int num = counterHumanCollisions + counterCollisions;
        return num;
    }

    public int GetNumErrorTrafficSign()
    {
        int num = counterErrorSpeed + counterErrorStopSign;
        return num;
    }

    public int GetNumErrorTrafficLaws()
    {
        int num = counterErrorWrongLane + counterErrorSeparationLine + counterErrorRedLight;
        return num;
    }

}

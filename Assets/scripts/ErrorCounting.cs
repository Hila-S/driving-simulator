using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCounting : MonoBehaviour
{
    [SerializeField] GameObject Car;
    CheckDirections checkDirections;
    NoEntrySign noEntry;
    RightOfWaySign rightOfWay;
    HumanCollision humanCollision;
    CarCollision carCollision;
    RedLight redLight;
    CheckSpeed checkSpeed;
    CheckRightLane checkRightLane;
    CorrectLaneTurns correctLaneTurns;
    SeparationLine separationLine;
    StopSign stopSign;

    /*int counterErrorDirections = 0;
    int counterHumanCollisions = 0;
    int counterCollisions = 0;
    int counterErrorRedLight = 0;
    int counterErrorSpeed = 0;
    int counterErrorWrongLane = 0;
    int counterErrorSeparationLine = 0;
    int counterErrorStopSign = 0;*/
    private int instructionErrors = 0;
    private int signErrors = 0;
    private int pedestrianErrors = 0;
    private int lightErrors = 0;
    private int speedErrors = 0;
    private int collisionErrors = 0;
    private int laneErrors = 0;


    void Awake()
    {
        DontDestroyOnLoad(this);
        checkDirections = Car.GetComponent<CheckDirections>();
        humanCollision = Car.GetComponent<HumanCollision>();
        carCollision = Car.GetComponent<CarCollision>();
        redLight = Car.GetComponent<RedLight>();
        checkSpeed = Car.GetComponent<CheckSpeed>();
        separationLine = Car.GetComponent<SeparationLine>();
        stopSign = Car.GetComponent<StopSign>();
        noEntry = Car.GetComponent<NoEntrySign>();
        rightOfWay = Car.GetComponent<RightOfWaySign>();
        checkRightLane = Car.GetComponent<CheckRightLane>();
        correctLaneTurns = Car.GetComponent<CorrectLaneTurns>();
    }

    // Update is called once per frame
    /*void Update()
    {
        counterErrorDirections = checkDirections.GetNumErrorDirction();
        counterHumanCollisions = humanCollision.GetNumHumanCollisions();
        counterCollisions = carCollision.GetNumHumanCollisions();
        counterErrorRedLight = redLight.GetNumErrorRedLight();
        counterErrorSpeed = checkSpeed.GetNumErrorSpeed();
        counterErrorSeparationLine = separationLine.GetNumErrorSeparationLine();
        counterErrorStopSign = stopSign.GetNumErrorStopSign();
        if (counterErrorSeparationLine >= 1)
        {
            Debug.Log("counterErrorSeparationLine:" + counterErrorSeparationLine);
        }
    }*/

    public void Update()
    {
        instructionErrors = checkDirections.GetNumErrorDirction();
        signErrors = noEntry.GetNumErrors() + rightOfWay.GetNumErrors() + stopSign.GetNumErrorStopSign();
        pedestrianErrors = humanCollision.GetNumHumanCollisions();
        lightErrors = redLight.GetNumErrorRedLight();
        speedErrors = checkSpeed.GetNumErrorSpeed();
        collisionErrors = carCollision.GetNumHumanCollisions();
        laneErrors = checkRightLane.GetNumErrors() + correctLaneTurns.GetNumErrors() + separationLine.GetNumErrorSeparationLine();
    }

    public int GetInstructionErrors()
    {
        return instructionErrors;
    }
    public int GetSignErrors()
    {
        return signErrors;
    }
    public int GetPedestrianErrors()
    {
        return pedestrianErrors;
    }
    public int GetLightErrors()
    {
        return lightErrors;
    }
    public int GetSpeedErrors()
    {
        return speedErrors;
    }
    public int GetCollisionErrors()
    {
        return collisionErrors;
    }
    public int GetLaneErrors()
    {
        return laneErrors;
    }

    /*public int GetErrorDirections()
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
    }*/

}

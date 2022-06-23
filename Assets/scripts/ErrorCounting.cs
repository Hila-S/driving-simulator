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

    /*group of get functions to get number of errors in each category*/
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

}

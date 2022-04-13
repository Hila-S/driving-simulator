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



    private int counterErrorDirections = 0;


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
    }

    // Update is called once per frame
    void Update()
    {
        counterErrorDirections = checkDirections.GetNumErrorDirction();
        int counterHumanCollisions = humanCollision.GetNumHumanCollisions();
        int counterCollisions = carCollision.GetNumHumanCollisions();
        int counterErrorRedLight = redLight.GetNumErrorRedLight();
        int counterErrorSpeed = checkSpeed.GetNumErrorSpeed();
        int counterErrorWrongLane = wrongLane.GetNumErrorWrongLane();
        int counterErrorSeparationLine = separationLine.GetNumErrorSeparationLine();
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
}

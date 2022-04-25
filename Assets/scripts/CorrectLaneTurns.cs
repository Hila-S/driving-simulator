using UnityEngine;
using System;
using System.Linq;

public class CorrectLaneTurns: WarningDisplayer
{
    private String warningText = "You have turned from the incorrect lane!";
    Arrows arrows;
    [SerializeField] GameObject Car;
    private String direction;
    private const string LEFT = "left";
    private const string RIGHT = "right";
    private const string STRAIGHT = "straight";
    private String[] turnCubes = { "l turn cube", "r turn cube", "ls turn cube", "rs turn cube", "s turn cube"};

    void Awake()
    {
        arrows = Car.GetComponent<Arrows>();
    }

    public void OnTriggerEnter(Collider col)
    {
        Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
        float xAbs = Mathf.Abs(delta.x);
        float yAbs = Mathf.Abs(delta.y);
        float zAbs = Mathf.Abs(delta.z);

        if (turnCubes.Contains(col.gameObject.name))
        {
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs && delta.z <= 0)
            {
                direction = arrows.GetDirection();
            }
        }

    }

    public void OnTriggerExit(Collider col)
    {
        Vector3 delta = col.gameObject.transform.InverseTransformPoint(gameObject.transform.position);
        float xAbs = Mathf.Abs(delta.x);
        float yAbs = Mathf.Abs(delta.y);
        float zAbs = Mathf.Abs(delta.z);

        if (turnCubes.Contains(col.gameObject.name))
        {
            if (!(xAbs > yAbs && xAbs > zAbs) && zAbs > yAbs && delta.z > 0)
            {
                if (direction == LEFT && (col.gameObject.name != "l turn cube" && col.gameObject.name != "ls turn cube"))
                {
                    displayWarning(warningText);
                }

                if (direction == RIGHT && (col.gameObject.name != "r turn cube" && col.gameObject.name != "rs turn cube"))
                {
                    displayWarning(warningText);
                }

                if (direction == STRAIGHT && (col.gameObject.name != "rs turn cube" && col.gameObject.name != "ls turn cube" && col.gameObject.name != "s turn cube"))
                {
                    displayWarning(warningText);
                }
            }
               
        }
    }
}

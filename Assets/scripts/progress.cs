/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Progress : MonoBehaviour
{
}
*/
using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using System;
using System.Text;

public class Progress : MonoBehaviour
{
    List<int> directionsArr = new List<int>();
    List<int> trafficSignsArr = new List<int>();
    List<int> pedestriansArr = new List<int>();
    List<int> trafficLightArr = new List<int>();
    List<int> speedLimitArr = new List<int>();
    List<int> collisionsArr = new List<int>();
    List<int> lanesArr = new List<int>();
    List<int> sumArr = new List<int>();

    /*
    int[] directionsArr = new int[6];
    int[] trafficSignsArr = new int[6];
    int[] pedestriansArr = new int[6];
    int[] trafficLightArr = new int[6];
    int[] speedLimitArr = new int[6];
    int[] collisionsArr = new int[6];
    int[] lanesArr = new int[6];
    int[] sumArr = new int[6];
    */
    int counter = 0;
    string userId ="";
    // Start is called before the first frame update
    void Start()
    {
        GameObject authManagerObject;
        AuthManager authManager;
        authManagerObject = GameObject.Find("AuthManager");
        if (authManagerObject == null)
        {
            Debug.Log("error in mail");
            userId = "dsda";
        }
        else
        {
            authManager = authManagerObject.GetComponent<AuthManager>();
            userId = authManager.getUserName();
        }

        PersonalProgress();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void PersonalProgress()
    {

        //check the number of games
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error!");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    //Debug.Log(user);
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        foreach (DataSnapshot game in user.Children)
                        {
                            counter++;
                        }
                    }
                }
            }
        });
        //string userId = "dsda";
        //int counter = 6;
        //take the progress in the last 6 games 
        bool boolean = false;
        int index = 0;
        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error!");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        foreach (DataSnapshot game in user.Children)
                        {
                            boolean = false;
                            string tempgame = game.Key.ToString();
                            if (String.Compare(("game" + counter), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 1;

                            }
                            else if (String.Compare(("game" + (counter - 1)), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 2;}
                            else if (String.Compare(("game" + (counter - 2)), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 3;}
                            else if (String.Compare(("game" + (counter - 3)), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 4; }
                            else if (String.Compare(("game" + (counter - 4)), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 5;
                            }
                            else if (String.Compare(("game" + (counter - 5)), tempgame) == 0)
                            {
                                boolean = true;
                                index = counter - 6;
                            }
                            if (boolean == true)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                               // Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                                insertArr(index, int.Parse(dictUser["followingDirections"].ToString()), int.Parse(dictUser["followingTrafficSigns"].ToString()), int.Parse(dictUser["attentionToPedestrians"].ToString()), int.Parse(dictUser["followingTrafficLights"].ToString()), int.Parse(dictUser["SpeedLimit"].ToString()), int.Parse(dictUser["CollisionsWithSidewalk"].ToString()), int.Parse(dictUser["followingLaneCorrectly"].ToString()));
                            }
                        }
                    }
                }
            }
        });
    }

    void insertArr(int i, int directions, int trafficSigns, int pedestrians, int trafficLight, int speedLimit, int collisions, int lanes)
    {
        directionsArr.Add(directions);
        trafficSignsArr.Add(trafficSigns);
        pedestriansArr.Add(pedestrians);
        trafficLightArr.Add(trafficLight);
        speedLimitArr.Add(speedLimit);
        collisionsArr.Add(collisions);
        lanesArr.Add(lanes);
        int sum = (directions + trafficSigns + pedestrians + trafficLight + speedLimit + collisions + lanes);
        sumArr.Add(sum);
    }

    public int[] getDirectionsArr()
    {
        int[] array = directionsArr.ToArray();
        return array;
    }
    public int[] getTrafficSignsArr()
    {
        int[] array = trafficSignsArr.ToArray();
        return array;
    }
    public int[] getPedestriansArr()
    {
        int[] array = pedestriansArr.ToArray();
        return array;
    }
    public int[] getTrafficLightArr()
    {
        int[] array = trafficLightArr.ToArray();
        return array;
    }
    public int[] getSpeedLimitArr()
    {
        int[] array = speedLimitArr.ToArray();
        return array;
    }
    public int[] getCollisionsArr()
    {
        int[] array = collisionsArr.ToArray();
        return array;
    }
    public int[] getLanesArr()
    {
        int[] array = lanesArr.ToArray();
        return array;
    }
    public int[] getSumArr()
    {
        int[] sumy = sumArr.ToArray();
        return sumy;
    }
}
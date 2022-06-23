
using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using System;

public class AdminFirebase : MonoBehaviour
{
    string state = "";
    string speed = "";
    string numCommands = "";
    string numDistance = "";
    string numTime = "";
    void Start()
    {
        StartFirebase();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void StartFirebase()
    {
        //create Dictionary of the command, distance, speed
        DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        dbInstance.GetReference("admin").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error_grade");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), "state") == 0)
                    {
                        state = user.Value.ToString();
                    }
                    else if (String.Compare(user.Key.ToString(), "commands") == 0)
                    {
                        numCommands = user.Value.ToString();
                    }
                    else if (String.Compare(user.Key.ToString(), "distance") == 0)
                    {
                        numDistance = user.Value.ToString();
                    }
                    else if (String.Compare(user.Key.ToString(), "speed") == 0)
                    {
                        speed = user.Value.ToString();
                    }
                    else if (String.Compare(user.Key.ToString(), "time") == 0)
                    {
                        numTime = user.Value.ToString();
                    }
                }
            }
        });
    }

    public void updateFirebaseAdmin(string typeEndGame, int num)
    {
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;

        //update Firebase Admin
        dbInstance.GetReference("admin").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error!");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), typeEndGame) == 0)
                    {
                        dbrefer.Child("admin").Child(typeEndGame).SetValueAsync(num);
                        //dbrefer
                    }   
                }
            }
            StartFirebase();
        });
    }

    public void updatestate(string state)
    {
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;

        //update Firebase Admin
        dbInstance.GetReference("admin").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error!");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), "state") == 0)
                    {
                        dbrefer.Child("admin").Child("state").SetValueAsync(state);
                    }
                }
            }
            StartFirebase();
        });
    }

    public string GetState()
    {
        return state;
    }
    public string GetSpeed()
    {
        return speed;
    }

    public string GetNum(string stateType)
    {
        if (stateType == "commands")
            return numCommands;
        else if (stateType == "distance")
            return numDistance;
        else if (stateType == "time")
            return numTime;
        return "";
    }

}
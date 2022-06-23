using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using System;
using System.Text;


public class Score
{
    public int followingDirections;
    public int followingTrafficSigns;
    public int attentionToPedestrians;
    public int followingTrafficLights;
    public int SpeedLimit;
    public int CollisionsWithSidewalk;
    public int followingLaneCorrectly;

    public Score(int followingDirections, int followingTrafficSigns, int attentionToPedestrians, int followingTrafficLights, int SpeedLimit, int CollisionsWithSidewalk, int followingLaneCorrectly)
    {
        this.followingDirections = followingDirections;
        this.followingTrafficSigns = followingTrafficSigns;
        this.attentionToPedestrians = attentionToPedestrians;
        this.followingTrafficLights = followingTrafficLights;
        this.SpeedLimit = SpeedLimit;
        this.CollisionsWithSidewalk = CollisionsWithSidewalk;
        this.followingLaneCorrectly = followingLaneCorrectly;
    }
}

public class scoreEndGame : MonoBehaviour
{
    GameObject authManagerObject;
    AuthManager authManager;
    int counter;

    void Start()
    {
      
    }

    public void addGameFirebase(int followingDirections, int followingTrafficSigns, int attentionToPedestrians, int followingTrafficLights, int SpeedLimit, int CollisionsWithSidewalk, int followingLaneCorrectly, int scoreGame)
    {
        String userId = "";
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
        string newString = "followingDirections: " + followingDirections + "\nfollowingTrafficSigns: " + followingTrafficSigns + "\nattentionToPedestrians: " + attentionToPedestrians + "\nfollowingTrafficLights: " + followingTrafficLights + "\nSpeedLimit: " + SpeedLimit + "\nCollisionsWithSidewalk: " + CollisionsWithSidewalk + "\nfollowingLaneCorrectly: " + followingLaneCorrectly;
        Score score = new Score(followingDirections, followingTrafficSigns, attentionToPedestrians, followingTrafficLights, SpeedLimit, CollisionsWithSidewalk, followingLaneCorrectly);
        string json = JsonUtility.ToJson(score);
        counter = 0;

        bool isNewUser = true;
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;
        //check in the database the number of game the user play

        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        isNewUser = false;
                        foreach (DataSnapshot game in user.Children)
                        {
                            counter++;
                        }
                        counter++;
                        String gameId = "game" + counter;
                        ////add the new game
                        dbrefer.Child("users").Child(userId).Child(gameId).SetRawJsonValueAsync(json);
                    }
                }
                if (isNewUser)
                {
                    dbrefer.Child("users").Child(userId).Child("game1").SetRawJsonValueAsync(json);
                }

            }
        });
        updateGradeUser(userId, scoreGame);

        Destroy(GameObject.Find("MyProgress"));
        Destroy(GameObject.Find("Progress"));
    }
    //update the grade of the user
    void updateGradeUser(string userId, int new_grade)
    {
        bool isNewUser = true;
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;
        dbInstance.GetReference("grade user").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error_grade");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        isNewUser = false;
                        int grade = int.Parse(user.Value.ToString());
                        if (new_grade > grade)
                        {
                            dbrefer.Child("grade user").Child(userId).SetValueAsync(new_grade);
                        }
                    }
                }
                if (isNewUser)
                    dbrefer.Child("grade user").Child(userId).SetValueAsync(new_grade);
            }
        });
    }

    public int getCounter()
    {
        return counter;
    }



}

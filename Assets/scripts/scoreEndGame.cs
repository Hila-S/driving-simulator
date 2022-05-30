using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreEndGame : MonoBehaviour
{
}
/*
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

public class ScoreEndGame : MonoBehaviour
{
    // private ErrorCounting errorCounting;
    GameObject errorCountingScore;
    ErrorCounting errorCounting;
    GameObject authManagerObject;
    AuthManager authManager;
    int counter;
    //public Text text;
    //public GameObject scoreCanvas;

    void Start()
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
            Debug.Log("userId:" + userId);
        }
        errorCountingScore = GameObject.Find("ErrorCountingScore");
        if (errorCountingScore == null)
            Debug.Log("error - ErrorCountingScore");
        else
        {
            //print the score to the sceen
*/
/*
errorCounting = errorCountingScore.GetComponent<ErrorCounting>();
int numErrorDirections = errorCounting.GetErrorDirections();
int numCollisions = errorCounting.GetNumCollisions();
int numTrafficSign = errorCounting.GetNumErrorTrafficSign();
int numTrafficLaws = errorCounting.GetNumErrorTrafficLaws();
//Debug.Log("GetErrorDirections:" + numErrorDirections);

string newString = "Error Directions: " + numErrorDirections + "\nCollisions: " + numCollisions
    + "\nError Traffic Sign: " + numTrafficSign + "\nError Traffic Laws: " + numTrafficLaws;
text.text = newString;
scoreCanvas.SetActive(true);
// here the change
String userId = "dsda";
DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

Score score = new Score(numErrorDirections, numCollisions, numTrafficSign, numTrafficLaws);
string json = JsonUtility.ToJson(score);

mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
*/
/*
}

int followingDirections = 6;
int followingTrafficSigns = 2;
int attentionToPedestrians = 0;
int followingTrafficLights = 4;
int SpeedLimit = 1;
int CollisionsWithSidewalk = 0;
int followingLaneCorrectly = 2;

string newString = "followingDirections: " + followingDirections + "\nfollowingTrafficSigns: " + followingTrafficSigns + "\nattentionToPedestrians: " + attentionToPedestrians + "\nfollowingTrafficLights: " + followingTrafficLights + "\nSpeedLimit: " + SpeedLimit + "\nCollisionsWithSidewalk: " + CollisionsWithSidewalk + "\nfollowingLaneCorrectly: " + followingLaneCorrectly;
//text.text = newString;
//scoreCanvas.SetActive(true);
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
    Debug.Log("error!");
else if (task.IsCompleted)
{
    DataSnapshot snapshot = task.Result;
    foreach (DataSnapshot user in snapshot.Children)
    {
        //Debug.Log(user);
        if (String.Compare(user.Key.ToString(), userId) == 0)
        {
            isNewUser = false;
            Debug.Log("compair");
            foreach (DataSnapshot game in user.Children)
            {
                counter++;
            }
            counter++;
            String gameId = "game" + counter;
            Debug.Log(gameId);
            ////add the new game
            // dbrefer.Child("users").Child(userId).Child(gameId).SetRawJsonValueAsync(json);
        }
    }
    if (isNewUser)
    {
        Debug.Log("hi");
        ///String gameId = "game1";
        //dbrefer.Child("users").Child(userId).Child(gameId).SetRawJsonValueAsync(json);
    }

}
});
grade_user(userId, 90);
}
//update the grade of the user
void grade_user(string userId, int new_grade)
{
bool isNewUser = true;
FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
DatabaseReference dbrefer = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/").RootReference;
Debug.Log("hello");
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
                Debug.Log("change!");
                dbrefer.Child("grade user").Child(userId).SetValueAsync(new_grade);
            }
        }
    }
    if (isNewUser)
    {
        Debug.Log("hi");
        dbrefer.Child("grade user").Child(userId).SetValueAsync(new_grade);
    }

}
});
}

public int getCounter()
{
return counter;
}
}
*/
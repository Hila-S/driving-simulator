using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class progress : MonoBehaviour
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


public class progress : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //
    public void PersonalProgress()
    {
        
        GameObject authManagerObject;
        AuthManager authManager;

        GameObject scoreEndGameObject;
        ScoreEndGame scoreEndGame;
        

        string userId;
        scoreEndGameObject = GameObject.Find("ScoreEndGame");
        scoreEndGame = scoreEndGameObject.GetComponent<ScoreEndGame>();
        int counter = scoreEndGame.getCounter();

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
        Debug.Log("userId:" + userId);
        
        //string userId = "dsda";
        //int counter = 6;
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
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        foreach (DataSnapshot game in user.Children)
                        {
                            string tempgame = game.Key.ToString();
                            if (String.Compare(("game"+counter), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                            else if (String.Compare(("game" + (counter-1)), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                            else if (String.Compare(("game" + (counter - 2)), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                            else if (String.Compare(("game" + (counter - 3)), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                            else if (String.Compare(("game" + (counter - 4)), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                            else if (String.Compare(("game" + (counter - 5)), tempgame) == 0)
                            {
                                IDictionary dictUser = (IDictionary)game.Value;
                                Debug.Log("-----" + tempgame + ":  " + dictUser["followingDirections"] + " -- " + dictUser["followingTrafficSigns"] + "-" + dictUser["attentionToPedestrians"] + "-" + dictUser["followingTrafficLights"] + "-" + dictUser["SpeedLimit"] + "-" + dictUser["CollisionsWithSidewalk"] + "-" + dictUser["followingLaneCorrectly"]);
                            }
                        }
                    }
                }
            }

        });
    }
}
*/
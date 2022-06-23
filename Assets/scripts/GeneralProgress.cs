
using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using System;

public class GeneralProgress : MonoBehaviour
{
    Dictionary<string, int> gradeDictionary = new Dictionary<string, int>();
    string userId = "";
    int gradeUser = 0;
    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameObject authManagerObject;
        AuthManager authManager;
        authManagerObject = GameObject.Find("AuthManager");
        if (authManagerObject == null)
        {
            userId = "dsda";
        }
        else
        {
            authManager = authManagerObject.GetComponent<AuthManager>();
            userId = authManager.getUserName();
        }
        FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.GetInstance("https://driving-simulator-new-default-rtdb.firebaseio.com/");
        dbInstance.GetReference("grade user").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("error_grade");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    string name = user.Key.ToString();
                    int grade = int.Parse(user.Value.ToString());
                    gradeDictionary.Add(name, grade);
                  
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        gradeUser = int.Parse(user.Value.ToString());
                    }
                }
            }
        });
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

     public Dictionary<string, int> getGradeDictionary()
     {
        return gradeDictionary;
     }

    public int getGradeUser()
    {
        return gradeUser;
    }

}
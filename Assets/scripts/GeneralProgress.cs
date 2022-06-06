/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralProgress : MonoBehaviour
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
//using System.Text;

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
            //Debug.Log("error in mail");
            userId = "dsda";
        }
        else
        {
            authManager = authManagerObject.GetComponent<AuthManager>();
            userId = authManager.getUserName();
        }
        //Dictionary<string, int> gradeDictionary = new Dictionary<string, int>();
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
                    // if (String.Compare(user.Key.ToString(), userId) != 0)
                    // {
                    string name = user.Key.ToString();
                    int grade = int.Parse(user.Value.ToString());
                    gradeDictionary.Add(name, grade);
                    //}
                    if (String.Compare(user.Key.ToString(), userId) == 0)
                    {
                        gradeUser = int.Parse(user.Value.ToString());
                    }
                }
            }/*
            foreach (KeyValuePair<string, int> kvp in gradeDictionary)
            {
                Debug.Log(kvp.Key + ": " + kvp.Value);
            }
            */
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
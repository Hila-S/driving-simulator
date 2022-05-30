using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AdminFirebase : MonoBehaviour
{

    public void Admin()
    {

    }
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

public class AdminFirebase : MonoBehaviour
{
    
    public void Admin()
    {
        Dictionary<string, string> openWith = new Dictionary<string, string>();

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
                    if (String.Compare(user.Key.ToString(), "astate") == 0)
                    {
                        openWith.Add("state", user.Value.ToString());
                    }
                    else if (String.Compare(user.Key.ToString(), "command") == 0)
                    {
                        openWith.Add("commands", user.Value.ToString());
                    }
                    else if(String.Compare(user.Key.ToString(), "distance") == 0)
                    {
                        openWith.Add("distance", user.Value.ToString());
                    }
                    else if(String.Compare(user.Key.ToString(), "speed") == 0)
                    {
                        openWith.Add("speed", user.Value.ToString());
                    }
                    else if(String.Compare(user.Key.ToString(), "time") == 0)
                    {
                        openWith.Add("time", user.Value.ToString());
                    }
                }
                foreach (KeyValuePair<string, string> kvp in openWith)
                {
                    Debug.Log(kvp.Key + ": " + kvp.Value);
                }
            }
        });
        
    }
}
*/
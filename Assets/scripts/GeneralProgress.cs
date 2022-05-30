using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralProgress : MonoBehaviour
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
//using System.Text;

public class GeneralProgress : MonoBehaviour
{
    public void Progress()
    {
        Dictionary<string, int> gradeDictionary = new Dictionary<string, int>();
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
                }
            }
            foreach (KeyValuePair<string, int> kvp in gradeDictionary)
            {
                Debug.Log(kvp.Key + ": " + kvp.Value);
            }
        });
    }
}
*/
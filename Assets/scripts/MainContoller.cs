using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Firebase;
//using FirebaseAuth.unitypackage;

public class MainContoller : MonoBehaviour
{

    //[SerializeField]
    //private InputFiled input;

    //void Awake(){
    //    //input = GameObject.Find ("InputField").GetComponent<InputField>();
    //}
    
    public void GetInput(string guess){
        Debug.Log("You Entered " + guess);
      //  input.text = "";
    }

   // auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
     //   if (task.IsCanceled)
       // {
         //   Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
           // return;
        //}
 //       if (task.IsFaulted)
   //     {
     //       Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
       //     return;
       // }

        // Firebase user has been created.
//        Firebase.Auth.FirebaseUser newUser = task.Result;
 //       Debug.LogFormat("Firebase user created successfully: {0} ({1})",
 //           newUser.DisplayName, newUser.UserId);
   // });
}
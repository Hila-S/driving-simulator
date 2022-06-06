using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LogoutBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Action action = () =>
        {
            Destroy(GameObject.Find("AuthManager"));
            SceneManager.LoadScene("LoginScene");
            // action for logout
        };
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            Popup popup = PopupManager.Instance.CreatePopup();
            popup.Init(PopupManager.Instance.MainCanvas,
                "Would You Like To Logout?",
                "Logout",
                "Cancel",
                action);


        });

    }
}

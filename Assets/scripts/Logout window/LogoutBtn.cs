using UnityEngine;
using UnityEngine.UI;
using System;

public class LogoutBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Action action = () =>
        {
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

using UnityEngine;
using UnityEngine.UI;
using System;
public class AdminSettingsBtn : MonoBehaviour
{
    [SerializeField] GameObject popup;
    GetAdminData getAdminData;

    // Start is called before the first frame update
    void Start()
    {
        getAdminData = popup.GetComponent<GetAdminData>();

        Action action = () =>
        {
            set_input();
        };

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            PopupSettings popup = UIController.Instance.CreatePopup();
            popup.Init(UIController.Instance.MainCanvas, action);


        });
    }

    void set_input()
    {
        string toggle = getAdminData.get_toggle();
        string end_input = getAdminData.get_end_input();
        string speed_input = getAdminData.get_speed_input();
        // send to firebase
        GameObject adminFirebaseObj;
        AdminFirebase adminFirebase;
        adminFirebaseObj = GameObject.Find("AdminFirebase");
        adminFirebase = adminFirebaseObj.GetComponent<AdminFirebase>();
        adminFirebase.updatestate(toggle);//update the state
        if (end_input != "")
            adminFirebase.updateFirebaseAdmin(toggle, int.Parse(end_input));//update the end_input
        if (speed_input != "")
            adminFirebase.updateFirebaseAdmin("speed", int.Parse(speed_input));//update the speed
    }
}

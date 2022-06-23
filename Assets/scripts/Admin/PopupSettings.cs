using UnityEngine;
using UnityEngine.UI;
using System;

public class PopupSettings : MonoBehaviour
{
    [SerializeField] GameObject popupInfo;
    [SerializeField] Button ok;
    [SerializeField] Button cancel;
    [SerializeField] Image settingsImg;


    public void Init(Transform canvas, Action action)
    {
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
        //when the admin presses "cancel" the popup closes without making any changes
        cancel.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
        //when the admin presses "ok" the action is called and then the popup is closed
        ok.onClick.AddListener(() =>
        {
            //we will get the action that we injected in the AdminSettingsBtn script that stores the data in the database
            action();
            GameObject.Destroy(this.gameObject);
        });
    }
}

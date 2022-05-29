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

        cancel.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
        ok.onClick.AddListener(() =>
        {
            action();
            GameObject.Destroy(this.gameObject);
        });
    }
}

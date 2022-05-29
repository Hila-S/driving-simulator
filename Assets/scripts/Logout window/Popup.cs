using UnityEngine;
using UnityEngine.UI;
using System;

public class Popup : MonoBehaviour
{
    [SerializeField] Button ok;
    [SerializeField] Button cancel;
    [SerializeField] Text ok_text;
    [SerializeField] Text cancel_text;
    [SerializeField] Text popup_text;

    public void Init(Transform canvas, string popupMassege, string okTxt, string cancelTxt, Action action)
    {
        popup_text.text = popupMassege;
        ok_text.text = okTxt;
        cancel_text.text = cancelTxt;

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

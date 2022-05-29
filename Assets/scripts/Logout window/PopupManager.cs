using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    public Transform MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public Popup CreatePopup()
    {
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopupWindow") as GameObject);
        return popUpGo.GetComponent<Popup>();
    }
}
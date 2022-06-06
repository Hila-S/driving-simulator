using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hii()
    {
        Destroy(GameObject.Find("AuthManager"));
        Destroy(GameObject.Find("Progress"));
        Destroy(GameObject.Find("MyProgress"));
        SceneManager.LoadScene("DrivingSimulator");
    }
}

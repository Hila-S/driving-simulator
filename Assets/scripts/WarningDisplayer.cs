using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class WarningDisplayer : MonoBehaviour
{
    public Text text;
    public GameObject warningCanvas;

    private float timer = 0.0f;
    private float howLongToDisplay = 5.0f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        warningCanvas.SetActive(false);
        audioSource = GameObject.Find("AudioSourceWarning").GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.Log("audio source is null!");
    }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > howLongToDisplay)
            {
                warningCanvas.SetActive(false);
                timer = 0.0f;
            }
        }

    public void displayWarning(String warning_text)
    {
        text.text = warning_text;
        warningCanvas.SetActive(true);
        if (audioSource == null)
        {
            audioSource = GameObject.Find("AudioSourceWarning").GetComponent<AudioSource>();
        }
       audioSource.Play();
    }
}

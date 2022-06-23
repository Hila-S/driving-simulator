using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AudioPlayerDirections : MonoBehaviour
{
    public AudioClip rightAudio;
    public AudioClip leftAudio;
    public AudioClip straightAudio;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.Log("audio source is null!");
    }


    public void playSound(string direction)
    {
        if (direction == "straight")
            audioSource.clip = straightAudio;
        if (direction == "left")
            audioSource.clip = leftAudio;
        if (direction == "right")
            audioSource.clip = rightAudio;
        audioSource.Play();
    }

}

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

    /*String[] direction_cubes = { "directions-rls", "directions-rls-70", "directions-rls-30", "directions-rl",
        "directions-rl-70", "directions-rl-30", "directions-rs", "directions-rs-70", "directions-rs-30", "directions-ls",
        "directions-ls-70", "directions-ls-30", "directions-l", "directions-l-70", "directions-l-30",
        "directions-r", "directions-r-70","directions-r-30", "directions-s", "directions-s-70", "directions-s-30"};*/


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.Log("audio source is null!");
        //if (audioClip == null)
        //  Debug.Log("audio clip is null!");
    }

    // Update is called once per frame
    void Update()
    {
        
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

    /*void OnTriggerEnter(Collider col)
    {
        if (direction_cubes.Contains(col.gameObject.name))
        {
            direction = arrows.GetDirection();
            if (direction == "straight")
            {

            }
            if (direction == "left")
            {

            }
            if (direction == "right")
            {

            }
        }

    }*/
}

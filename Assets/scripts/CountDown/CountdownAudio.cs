using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip countAudio;
    public AudioClip goodLuckAudio;
    void Start()
    {
        audioSource = GameObject.Find("Countdown").GetComponent<AudioSource>();
    }
    public void PlayCountAudio()
    {
        audioSource.clip = countAudio;
        audioSource.Play();
    }
    public void PlayGoodLuckAudio()
    {
        audioSource.clip = goodLuckAudio;
        audioSource.Play();
    }
}

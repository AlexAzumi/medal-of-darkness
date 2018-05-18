using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicFadeIn : MonoBehaviour 
{
    public int secondsToFade = 2;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (audioSource.volume < 1)
        {
            audioSource.volume += (Time.deltaTime / (secondsToFade + 1));
        }
        else
        {
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicFadeIn : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public int secondsToFade = 2;

    private AudioSource audioSource;
    private ConfigManager m_ConfigManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        m_ConfigManager = GameObject.Find("ConfigManager").GetComponent<ConfigManager>();
    }

    private void FixedUpdate()
    {
        if (audioSource.volume < m_ConfigManager.m_ActualVolume)
        {
            audioSource.volume += (Time.deltaTime / (secondsToFade + 1));
        }
        else
        {
            Destroy(this);
        }
    }
}

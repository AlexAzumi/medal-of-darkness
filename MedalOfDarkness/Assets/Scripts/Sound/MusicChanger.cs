using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public AudioSource m_ActualSource, m_NewSource;
    public float m_SecondsToFade = 10.0f;

    private ConfigManager m_ConfigManager;
    private bool m_FadeIn = false;
    private bool m_FadeOut = false;

    private void Start()
    {
        m_ConfigManager = GameObject.Find("ConfigManager").GetComponent<ConfigManager>();
    }

    private void Update()
    {
        if (m_FadeIn)
        {
            if (m_ActualSource.volume > 0.0f)
            {
                m_ActualSource.volume -= (Time.deltaTime / (m_SecondsToFade + 1));
            }
            else
            {
                if (!m_NewSource.isPlaying)
                {
                    m_NewSource.Play();
                }

                if (m_NewSource.volume < m_ConfigManager.m_ActualVolume)
                {
                    m_NewSource.volume += (Time.deltaTime / (m_SecondsToFade + 1));
                }
                else
                {
                    m_FadeIn = false;
                }
            }
        }

        if (m_FadeOut)
        {
            if (m_NewSource.volume > 0.0f)
            {
                m_NewSource.volume -= (Time.deltaTime / (m_SecondsToFade + 1));
            }
            else
            {
                if (m_NewSource.isPlaying)
                {
                    m_NewSource.Stop();
                }

                if (m_ActualSource.volume < m_ConfigManager.m_ActualVolume)
                {
                    m_ActualSource.volume += (Time.deltaTime / (m_SecondsToFade + 1));
                }
                else
                {
                    m_FadeOut = false;
                }
            }
        }
    }

    public void StartChange()
    {
        m_FadeIn = true;
    }

    public void RevertChange()
    {
        m_FadeOut = true;
    }
}

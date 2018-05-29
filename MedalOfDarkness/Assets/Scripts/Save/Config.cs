using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Config
{
    private float m_Volume;

    public Config(float volume)
    {
        m_Volume = volume;
    }

    public float GetVolume()
    {
        return m_Volume;
    }

    public void SetVolume(float volume)
    {
        m_Volume = volume;
    }
}

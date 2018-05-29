using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public float m_ActualVolume = 1.0f;
    public AudioSource[] m_AudioSource;
    public Slider m_VolumeSlider;

    private void Start()
    {
        Config actualConfig = LoadConfig();
        if (actualConfig != null)
        {
            m_ActualVolume = actualConfig.GetVolume();
            m_VolumeSlider.value = m_ActualVolume * 100;
            ApplyChanges();
        }
    }

    public void SetVolume(float volume)
    {
        m_ActualVolume = volume / 100;
        ApplyChanges();
    }

    public void ApplyChanges()
    {
        for (int i = 0; i < m_AudioSource.Length; i++)
        {
            m_AudioSource[i].volume = m_ActualVolume;
        }
    }

    public void SaveData()
    {
        Config config = new Config(m_ActualVolume);
        SaveConfig(config);
    }

    private void SaveConfig(Config config)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/config.save");
        bf.Serialize(file, config);
        file.Close();
        Debug.Log("Configuration was saved");
    }

    private Config LoadConfig()
    {
        Config config;
        if (File.Exists(Application.persistentDataPath + "/config.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                FileStream file = File.Open(Application.persistentDataPath + "/config.save", FileMode.Open);
                config = (Config)bf.Deserialize(file);
                file.Close();
                return config;
            }
            catch (FileNotFoundException ex)
            {
                Debug.Log("No configuration file was found > " + ex.Message);
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}

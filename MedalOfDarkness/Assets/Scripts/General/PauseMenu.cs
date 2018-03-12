using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public GameObject m_MainPanel;

    /* Private stuff */
    private AudioSource m_BackgroundMusic;

    void Start()
    {
        m_BackgroundMusic = GameObject.Find("Katherine").GetComponent<AudioSource>();
    }

	void Update() 
    {
        if (m_MainPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                m_MainPanel.SetActive(false);
                Time.timeScale = 1.0f;
                m_BackgroundMusic.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                m_MainPanel.SetActive(true);
                Time.timeScale = 0f;
                m_BackgroundMusic.Pause();
            }
        }
	}

    public bool GetPauseActive()
    {
        return m_MainPanel.activeSelf;
    }
}

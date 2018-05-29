using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public GameObject m_MainPanel;
    public GameObject m_PausePanel, m_OptionsPanel, m_ConfirmPanel;
    public GameObject m_SelectedObject, m_ConfigSelected, m_ExitSelected;
    public ConfigManager m_ConfigManager;

    /* Private stuff */
    private AudioSource m_BackgroundMusic;
    private SelectOnInput m_Select;

    void Start()
    {
        m_BackgroundMusic = GameObject.Find("Katherine").GetComponent<AudioSource>();
        m_Select = GetComponent<SelectOnInput>();
    }

	void Update() 
    {
        if (m_MainPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                PauseGame(false);
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                PauseGame(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                PauseGame(true);
            }
        }
	}

    public bool GetPauseActive()
    {
        return m_MainPanel.activeSelf;
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            if (!m_PausePanel.activeSelf)
            {
                m_PausePanel.SetActive(true);
                m_OptionsPanel.SetActive(false);
            }
            m_MainPanel.SetActive(true);
            Time.timeScale = 0f;
            m_BackgroundMusic.Pause();
            m_Select.SelectSelected(m_SelectedObject);
        }
        else
        {
            if (m_PausePanel.activeSelf)
            {
                m_MainPanel.SetActive(false);
                Time.timeScale = 1.0f;
                m_BackgroundMusic.Play();
                m_Select.RemoveSelection();
            }
            else if(m_OptionsPanel.activeSelf)
            {
                m_ConfigManager.SaveData();
                m_PausePanel.SetActive(true);
                m_OptionsPanel.SetActive(false);
                m_Select.SelectSelected(m_ConfigSelected);
            }
            else if(m_ConfirmPanel.activeSelf)
            {
                m_PausePanel.SetActive(true);
                m_ConfirmPanel.SetActive(false);
                m_Select.SelectSelected(m_ExitSelected);
            }
        }
    }
}

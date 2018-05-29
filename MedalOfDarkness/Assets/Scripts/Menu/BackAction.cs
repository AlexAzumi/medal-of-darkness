using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackAction : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventSystem m_EventSystem;
    public GameObject m_OptionsMenu;
    public GameObject m_LoginMenu;
    public GameObject m_MainMenu;
    public GameObject m_OptionButton;
    public GameObject m_NewGameButton;
    public ConfigManager m_ConfigManager;

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && m_MainMenu.activeSelf == false)
        {
            if (m_OptionsMenu.activeSelf == true)
            {
                m_ConfigManager.SaveData();
                m_OptionsMenu.SetActive(false);
                m_MainMenu.SetActive(true);
                m_EventSystem.SetSelectedGameObject(m_OptionButton);
            }
            else if (m_LoginMenu.activeSelf == true)
            {
                m_LoginMenu.SetActive(false);
                m_MainMenu.SetActive(true);
                m_EventSystem.SetSelectedGameObject(m_NewGameButton);
            }
        }
	}
}

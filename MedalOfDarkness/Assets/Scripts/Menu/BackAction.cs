using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackAction : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventSystem m_EventSystem;
    public GameObject m_OptionsMenu;
    public GameObject m_MainMenu;
    public GameObject m_OptionText;

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && m_MainMenu.activeSelf == false)
        {
            if (m_OptionsMenu.activeSelf == true)
            {
                m_OptionsMenu.SetActive(false);
                m_MainMenu.SetActive(true);
                m_EventSystem.SetSelectedGameObject(m_OptionText);
            }
        }
	}
}

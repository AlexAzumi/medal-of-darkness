using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventSystem m_EventSystem;
    public GameObject m_PreviousPanel;
    public GameObject m_PreviousPanelSelected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            m_EventSystem.SetSelectedGameObject(m_PreviousPanelSelected);
            m_PreviousPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_DialogBox;
    public Text m_DialogText;
    public PauseMenu m_PauseMenu;

    /* Private stuff */
    private PlayerController m_CharacterControl;
    private bool m_Active, m_ShowAll;
    private string[] m_DialogMessage;
    private int m_Count;

	private void Start() 
    {
        m_CharacterControl = GameObject.Find("Katherine").GetComponent<PlayerController>();
        m_ShowAll = false;
        m_Count = 0;
	}
	
	private void Update() 
    {
        if (m_Active && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && !m_PauseMenu.GetPauseActive())
        {
            if (m_ShowAll)
            {
                m_DialogBox.SetActive(false);
                m_Active = false;
                m_Count = 0;
                m_ShowAll = false;
                m_CharacterControl.SetCanMove(true);
            }
            else
            {
                m_Count++;
                ShowNext();
            }
        }
	}

    private void ShowNext()
    {
        //Debug.Log(m_Count + " | " + m_DialogMessage.Length);
        if (m_Count < m_DialogMessage.Length)
        {
            m_DialogText.text = m_DialogMessage[m_Count];
            if (!m_Active)
            {
                m_CharacterControl.SetCanMove(false);
                m_DialogBox.SetActive(true);
                m_Active = true;
            }
            if (m_Count == m_DialogMessage.Length - 1)
                m_ShowAll = true;
        }
    }

    public void SetMessageDialog(string[] dialogText)
    {
        m_DialogMessage = dialogText;
        m_CharacterControl.SetAnimation("IsWalking", false);
        m_CharacterControl.SetAnimation("IsRunning", false);
        ShowNext();
    }
}

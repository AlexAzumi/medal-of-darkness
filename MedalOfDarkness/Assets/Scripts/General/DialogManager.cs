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
    public float m_WaitTime;

    /* Private stuff */
    private PlayerController m_CharacterControl;
    private bool m_Active, m_ShowAll;
    private string[] m_DialogMessage;
    private int m_Count, m_CharPosition;
    private float m_Timer;

	private void Start() 
    {
        m_CharacterControl = GameObject.Find("Katherine").GetComponent<PlayerController>();
        m_ShowAll = false;
        m_Count = 0;
        m_CharPosition = 0;
        m_Timer = m_WaitTime;
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
                ShowNext();
            }
        }
        ShowMessage();
	}

    private void ShowMessage()
    {
        if (m_Active == true && m_CharPosition < m_DialogMessage[m_Count].Length)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer < 0)
            {
                m_DialogText.text += m_DialogMessage[m_Count][m_CharPosition];
                m_Timer = m_WaitTime;
                m_CharPosition++;
            }
        }
    }

    private void ShowNext()
    {
        if (m_CharPosition < m_DialogMessage[m_Count].Length && m_Active == true)
        {
            m_DialogText.text = m_DialogMessage[m_Count];
            m_CharPosition = m_DialogMessage[m_Count].Length;
        }
        else
        {
            m_DialogText.text = "";
            m_CharPosition = 0;
            if (!m_Active)
            {
                m_CharacterControl.SetCanMove(false);
                m_DialogBox.SetActive(true);
                m_Active = true;
            }
            else
            {
                m_Count++;
            }
            if (m_Count == m_DialogMessage.Length - 1)
            {
                m_ShowAll = true;
            }
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

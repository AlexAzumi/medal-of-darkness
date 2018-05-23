using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperText : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_Text;
    public Animator m_Animator;
    public PlayerController m_Player;
    public Animator m_PlayerAnimator;
    public PauseMenu m_PauseMenu;

    private bool showing = false;

    public void ShowPaper(string[] text)
    {
        m_Text.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            m_Text.text += text[i];
            if (i + 1 < text.Length)
            {
                m_Text.text += "\n";
            }
        }
        m_Animator.SetBool("isShowing", true);
        showing = true;
        m_Player.m_CanMove = false;
        m_PlayerAnimator.SetBool("IsWalking", false);
        m_PlayerAnimator.SetBool("IsRunning", false);
    }

    private void Update()
    {
        if (showing && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3)) && !m_PauseMenu.GetPauseActive())
        {
            HidePaper();
            showing = false;
        }
    }

    private void HidePaper()
    {
        m_Animator.SetBool("isShowing", false);
        m_Player.m_CanMove = true;
    }
}

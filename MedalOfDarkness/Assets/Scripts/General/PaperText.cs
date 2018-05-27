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

    public void ShowPaper(string[] text)
    {
        Debug.Log("Abriendo pergamino...");
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
        m_Player.m_CanMove = false;
        m_PlayerAnimator.SetBool("IsWalking", false);
        m_PlayerAnimator.SetBool("IsRunning", false);
        Debug.Log("Pergamino abierto");
    }

    private void Update()
    {
        if (m_Text.color.a == 1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3)) && !m_PauseMenu.GetPauseActive())
        {
            Debug.Log("Se ha solicitado ocultar el pergamino");
            HidePaper();
        }
    }

    private void HidePaper()
    {
        Debug.Log("Ocultando pergamino...");
        m_Animator.SetBool("isShowing", false);
        m_Player.m_CanMove = true;
        Debug.Log("Pergamino ocultado");
    }
}

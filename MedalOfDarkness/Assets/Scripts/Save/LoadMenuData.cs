using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuData : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_UserText;
    public Button m_ResumeGameButton;

    public Text m_UserFile1, m_UserFile2, m_UserFile3;
    public Text m_TimeFile1, m_TimeFile2, m_TimeFile3;

    private SaveLoad m_SaveLoad;
    private List<Game> m_Games;

    private void Start()
    {
        m_SaveLoad = new SaveLoad();
        CheckIfUser();
        CheckIfGames();
    }

    private void CheckIfUser()
    {
        User user = m_SaveLoad.LoadUser();
        if (user != null)
        {
            m_UserText.text = "<b>Usuario:</b> " + user.m_Username;
        }
        else
        {
            Color color = m_UserText.color;
            color.a = 0.0f;
            m_UserText.color = color;
        }
    }

    private void CheckIfGames()
    {
        m_Games = m_SaveLoad.LoadGames();
        if (m_Games != null)
        {
            m_ResumeGameButton.interactable = true;
            for (int i = 0; i < 3; i++)
            {
                if (m_Games[i] != null)
                {
                    switch (i)
                    {
                        case 3:
                            m_UserFile3.text = "Nombre del jugador: " + m_Games[2].GetUsername();
                            m_TimeFile3.text = "Tiempo jugado: " + m_Games[2].GetTime();
                            SetAlpha(3);
                            break;
                        case 2:
                            m_UserFile2.text = "Nombre del jugador: " + m_Games[1].GetUsername();
                            m_TimeFile2.text = "Tiempo jugado: " + m_Games[1].GetTime();
                            SetAlpha(2);
                            break;
                        case 1:
                            m_UserFile1.text = "Nombre del jugador: " + m_Games[0].GetUsername();
                            m_TimeFile1.text = "Tiempo jugado: " + m_Games[0].GetTime();
                            SetAlpha(1);
                            break;
                    }
                }
            }
        }
    }

    private void SetAlpha(int fileSave)
    {
        Color color = m_UserFile1.color;
        color.a = 1.0f;
        switch (fileSave)
        {
            case 1:
                m_UserFile1.color = color;
                m_TimeFile1.color = color;
                break;
            case 2:
                m_UserFile2.color = color;
                m_TimeFile2.color = color;
                break;
            case 3:
                m_UserFile1.color = color;
                m_TimeFile1.color = color;
                break;
        }
    }
}

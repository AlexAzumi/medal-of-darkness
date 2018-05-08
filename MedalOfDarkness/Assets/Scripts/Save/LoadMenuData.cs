using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuData : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_UserText;
    public Button m_ResumeGameButton;

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
        }
    }
}

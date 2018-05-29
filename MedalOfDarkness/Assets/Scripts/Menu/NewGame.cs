using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public SelectOnInput m_Select;
    public AudioSource m_SFX;
    public GameObject m_SelectedInput;
    public GameObject m_Login;
    public GameObject m_MainMenu;
    public Animator m_BetweenScenes;
    public int m_SecondsToFade = 1;
    public AudioSource m_BGM;

    private SaveLoad m_SaveLoad;
    private bool m_FadeOut;

    public void LoadSceneCall()
    {
        m_SaveLoad = new SaveLoad();
        User user = m_SaveLoad.LoadUser();
        if (user != null)
        {
            m_FadeOut = true;
            m_BetweenScenes.SetTrigger("fadeOut");
        }
        else
        {
            m_SFX.Play();
            m_MainMenu.SetActive(false);
            m_Login.SetActive(true);
            m_Select.SelectSelected(m_SelectedInput);
        }
    }

    public void Update()
    {
        if (m_FadeOut)
        {
            if (m_BGM.volume > 0)
            {
                m_BGM.volume -= (Time.deltaTime / (m_SecondsToFade + 1));
            }
            else
            {
                m_FadeOut = false;
            }
        }
    }
}

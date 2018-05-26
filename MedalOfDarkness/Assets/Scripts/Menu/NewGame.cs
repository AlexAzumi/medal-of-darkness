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

    private SaveLoad m_SaveLoad;

    public void LoadSceneCall()
    {
        m_SaveLoad = new SaveLoad();
        User user = m_SaveLoad.LoadUser();
        if (user != null)
        {
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
}

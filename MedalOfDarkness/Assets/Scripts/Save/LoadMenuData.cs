using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadMenuData : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_UserText;
    public Text m_CloseSession;
    public LevelScore m_LevelScore;

    private SaveLoad m_SaveLoad;
    private bool m_Session;
    private string m_Username;

    private void Start()
    {
        m_Session = false;
        m_SaveLoad = new SaveLoad();
        CheckIfUser();
        SendToScore();
    }

    private void CheckIfUser()
    {
        User user = m_SaveLoad.LoadUser();
        if (user != null)
        {
            m_Username = user.m_Username;
            m_UserText.text = "<b>Usuario:</b> " + user.m_Username;
            m_Session = true;
        }
        else
        {
            Color color = m_UserText.color;
            color.a = 0.0f;
            m_UserText.color = color;
            m_CloseSession.color = color;
        }
    }

    private void SendToScore()
    {
        try
        {
            m_LevelScore = GameObject.FindGameObjectWithTag("LevelScore").GetComponent<LevelScore>();
            m_LevelScore.SetUsername(m_Username);
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("Mensaje: " + ex.Message);
            Debug.Log("ScoreManager no existe");
        }
    }

    private void Update()
    {
        if (m_Session && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3)) && SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            m_Session = false;
            if (m_SaveLoad.DeleteUser())
            {
                Debug.Log("Usuario eliminado");
                CheckIfUser();
            }
            else
            {
                Debug.Log("No se pudo eliminar el usuario");
            }
        }
    }
}

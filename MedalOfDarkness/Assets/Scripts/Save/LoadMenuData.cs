using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenuData : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_UserText;
    public Text m_CloseSession;

    private SaveLoad m_SaveLoad;
    private bool m_Session;

    private void Start()
    {
        m_Session = false;
        m_SaveLoad = new SaveLoad();
        CheckIfUser();
    }

    private void CheckIfUser()
    {
        User user = m_SaveLoad.LoadUser();
        if (user != null)
        {
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

    private void Update()
    {
        if (m_Session && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3)))
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

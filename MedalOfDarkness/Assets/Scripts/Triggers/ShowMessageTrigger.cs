using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessageTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string m_Text;
    public string m_ActionText;
    public float m_WaitTime = 5.0f;

    /* Private stuff */
    private MessageText m_Event01;


    void Start()
    {
        m_Event01 = GameObject.Find("GameManager").GetComponent<MessageText>();
    }
        
    void OnTriggerEnter()
    {
        m_Event01.SetMessageText(m_Text, true);
    }

    void OnTriggerExit()
    {
        m_Event01.SetMessageText("", false);
    }

    void OnDisable()
    {
        m_Event01.SetMessageText("", false);
    }

    void OnTriggerStay()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)) && m_ActionText.Length > 0)
        {
            m_Event01.ShowMessageInTime(m_ActionText, m_WaitTime);
        }
    }
}


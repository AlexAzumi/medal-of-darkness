using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventAction : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public int m_CallEvent;
    public EventSelector m_EventSelector;
    public PlayerController m_Katherine;

    public void OnTriggerStay()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)) && m_Katherine.m_CanMove)
        {
            m_EventSelector.SendToEvent(m_CallEvent);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public float m_WaitTime = 2.0f;
    public int m_CallEvent;
    public EventSelector m_EventSelector;

    private float m_Count = 0.0f;
    private bool m_Finished = false;

    private void OnTriggerStay()
    {
        Debug.Log("Esperando...");
        m_Count += Time.deltaTime;
        if (m_Count > m_WaitTime && !m_Finished)
        {
            Debug.Log("Espera terminada");
            m_Count = 0;
            m_EventSelector.SendToEvent(m_CallEvent);
        }
    }

    private void OnTriggerExit()
    {
        m_Count = 0.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventTwo m_Event;
    public int m_EventNumber;

    private void OnTriggerEnter()
    {
        m_Event.SetMessages(m_EventNumber);
        GetComponent<BoxCollider>().enabled = false;
    }
}

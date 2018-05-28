using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventGeneric : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public int m_CallEvent;
    public EventSelector m_EventSelector;
    public bool m_DesactivateTrigger = false;

    private void OnTriggerEvent()
    {
        CallEvent();
        if (m_DesactivateTrigger)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void CallEvent()
    {
        m_EventSelector.SendToEvent(m_CallEvent);
    }
}

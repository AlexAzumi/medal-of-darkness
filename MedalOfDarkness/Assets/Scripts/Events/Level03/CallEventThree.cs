using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventThree : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventThree m_Event;
    public int m_EventNumber;

    private void OnTriggerEnter()
    {
        m_Event.SetEvent(m_EventNumber);
        GetComponent<BoxCollider>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeEvent : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public EventFour m_Event;
    public GameObject m_Katherine;
    public Animator m_BlackScreen;

    private void OnTriggerEnter()
    {
        if (!m_Event.solved)
        {
            m_BlackScreen.SetBool("isActive", true);
            m_Katherine.GetComponent<PlayerController>().m_CanMove = false;
            m_Katherine.GetComponent<Animator>().SetBool("IsWalking", false);
            m_Katherine.GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public float m_WaitTime = 3.0f;
    public PlayerController m_Controller;
    public Transform m_Katherine;
    public Transform m_RestartPosition;
    public Animator m_BlackScreen;

    private float m_Timer = 0;
    private bool m_Restart = false;

    public void Update()
    {
        if (m_Restart)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_WaitTime)
            {
                m_Katherine.position = m_RestartPosition.position;
                m_BlackScreen.SetBool("isActive", false);
                m_Controller.m_CanMove = true;
                m_Restart = false;
                m_Timer = 0;
            }
        }
    }

    public void Restart()
    {
        m_BlackScreen.SetBool("isActive", true);
        m_Controller.m_CanMove = false;
        m_Restart = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle01 : MonoBehaviour 
{
    /* Made by Aldan Project */
    public float m_XPosition, m_YPosition, m_ZPosition;
    public float m_SmoothTime = 5.0f;
    public Transform m_Barrel;
    public GameObject m_Trigger;

    public Event m_Event;

    private bool m_Activated;
    private Vector3 m_TargetPosition;

    private void Start()
    {
        m_Activated = false;
        m_TargetPosition = m_Barrel.position + new Vector3(m_XPosition, m_YPosition, m_ZPosition);
    }

    private void FixedUpdate()
    {
        if (m_Activated)
        {
            m_Barrel.position = Vector3.Lerp(m_Barrel.position, m_TargetPosition, 1.0f);
        }
        if (m_Activated && m_Barrel.position.Equals(m_TargetPosition))
        {
            m_Activated = false;
            m_Event.m_Barrel = true;
            m_Trigger.SetActive(false);
        }
    }

    public void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0)
        {
            m_Activated = true;
        }
    }
}

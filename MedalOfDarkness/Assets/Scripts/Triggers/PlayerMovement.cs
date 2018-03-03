using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public bool m_PlayerCanRun = true;

    /* Private stuff */
    private Event01 m_Event01;

    void Start()
    {
        m_Event01 = GameObject.Find("GameManager").GetComponent<Event01>();
    }

    void OnTriggerEnter()
    {
        m_Event01.PlayerCanRun(m_PlayerCanRun);
    }
}

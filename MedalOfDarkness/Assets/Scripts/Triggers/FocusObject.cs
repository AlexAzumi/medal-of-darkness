using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public Transform m_Object;
    public Event m_Event;
    public float m_FocusTime = 5f;

    /* Private stuff */
    private CameraFollow m_CameraFollow;
    private Animator m_Bars;
    private float m_Count;
    private bool m_Active;

	void Start()
    {
        m_CameraFollow = Camera.main.GetComponent<CameraFollow>();
        m_Bars = GameObject.FindGameObjectWithTag("Bars").GetComponent<Animator>();
        m_Event = GameObject.Find("GameManager").GetComponent<Event>();
        m_Active = false;
	}

    void Update()
    {
        if (m_Active)
        {
            m_Count += Time.deltaTime;
            if (m_Count > m_FocusTime)
            {
                m_CameraFollow.SetPlayerAsTarget();
                m_Bars.SetBool("isActive", false);
                m_Active = false;
                m_Event.SetMessages();
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void OnTriggerEnter()
    {
        m_CameraFollow.SetTarget(m_Object);
        m_Bars.SetBool("isActive", true);
        m_Active = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObjectGeneric : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public int m_CallEvent;
    public float m_FocusTime = 5f;
    public bool m_DesactivateTrigger = true;
    public Transform m_Object;
    public EventSelector m_Event;
    public Animator m_CharacterAnimator;

    /* Private stuff */
    private CameraFollow m_CameraFollow;
    private Animator m_Bars;
    private float m_Count;
    private bool m_Active;

	private void Start()
    {
        m_CameraFollow = Camera.main.GetComponent<CameraFollow>();
        m_Bars = GameObject.FindGameObjectWithTag("Bars").GetComponent<Animator>();
        m_Event = GameObject.Find("GameManager").GetComponent<EventSelector>();
        m_Active = false;
	}

    private void Update()
    {
        if (m_Active)
        {
            m_Count += Time.deltaTime;
            if (m_Count > m_FocusTime)
            {
                m_CameraFollow.SetPlayerAsTarget();
                m_Bars.SetBool("isActive", false);
                m_Active = false;
                m_Event.SendToEvent(m_CallEvent);
                if (m_DesactivateTrigger)
                {
                    GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter()
    {
        FocusObject();
    }

    public void FocusObject()
    {
        m_CharacterAnimator.SetBool("IsRunning", false);
        m_CharacterAnimator.SetBool("IsWalking", false);
        m_CameraFollow.SetTarget(m_Object);
        m_Bars.SetBool("isActive", true);
        m_Active = true;
    }
}

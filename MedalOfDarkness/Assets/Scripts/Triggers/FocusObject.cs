using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public Transform m_Object;
    public float m_FocusTime = 5f;

    /* Private stuff */
    private CameraFollow m_CameraFollow;
    private float m_Count;
    private bool m_Active;

	void Start()
    {
        m_CameraFollow = Camera.main.GetComponent<CameraFollow>();
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
                m_Active = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void OnTriggerEnter()
    {
        m_CameraFollow.SetTarget(m_Object);
        m_Active = true;
    }
}

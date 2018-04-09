using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public float m_Smooting = 5.0f;
    public float m_XOffset = -0.4f;
    public float m_ZOffset = 0.4f;
    public int m_YOffset = 1;

    /* Private stuff */
    private Transform m_Target;
    private Vector3 m_TargetCamPos;
    private PlayerController m_CharacterControl;
    private bool m_PlayerAsTarget;

    void Start()
    {
        m_Target = GameObject.Find("Katherine").GetComponent<Transform>();
        m_CharacterControl = GameObject.Find("Katherine").GetComponent<PlayerController>();
        m_PlayerAsTarget = true;
    }

	void FixedUpdate() 
    {
        m_TargetCamPos = m_Target.position;

        if(m_PlayerAsTarget) //Adds offset if the camera is following the player
            m_TargetCamPos += new Vector3(m_XOffset, m_YOffset, m_ZOffset);
        
        transform.position = Vector3.Lerp(transform.position, m_TargetCamPos, m_Smooting * Time.deltaTime);	
	}

    public void SetPlayerAsTarget()
    {
        m_Target = GameObject.Find("Katherine").GetComponent<Transform>();
        m_PlayerAsTarget = true;
        m_CharacterControl.SetCanMove(true);
    }

    public void SetTarget(Transform target)
    {
        m_CharacterControl.SetCanMove(false);
        m_Target = target;
        m_PlayerAsTarget = false;
    }
}

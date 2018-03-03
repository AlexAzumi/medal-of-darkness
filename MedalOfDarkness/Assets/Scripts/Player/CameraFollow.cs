using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* PUBLIC VARIABLES */
    public Transform m_Target;
    public float m_Smooting = 5.0f;
    public float m_XOffset = -0.4f;
    public float m_ZOffset = 0.4f;

    /* PRIVATE VARIABLES */
    private Vector3 m_TargetCamPos;

	void FixedUpdate() 
    {
        m_TargetCamPos = m_Target.position + new Vector3(m_XOffset, 0.0f, m_ZOffset);
        transform.position = Vector3.Lerp(transform.position, m_TargetCamPos, m_Smooting * Time.deltaTime);	
	}
}

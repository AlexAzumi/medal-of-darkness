using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaluMovement : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public bool m_Following = true;
    public Transform m_Katherine;
    public float m_Smooting = 2.0f;
    public float m_XOffset = -0.35f;
    public float m_YOffset = 1.2f;
    public float m_ZOffset = -0.25f;

    private Vector3 m_TargetPosition;
    private Quaternion m_TargetRotation;

    private void FixedUpdate()
    {
        if (m_Following)
        {
            m_TargetPosition = m_Katherine.position;
            m_TargetRotation = m_Katherine.rotation;
            m_TargetPosition += new Vector3(m_XOffset, m_YOffset, m_ZOffset);

            transform.position = Vector3.Lerp(transform.position, m_TargetPosition, m_Smooting * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetRotation, m_Smooting * Time.deltaTime);
        }
    }

    public void FollowKatherine()
    {
        m_Following = true;
    }
}

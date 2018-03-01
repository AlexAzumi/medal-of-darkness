using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event01 : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public PlayerController m_Player;
    public Text m_MessageText;
    public Image m_BlackScreen;
    public float m_InactiveTime = 5f;

    /* Private stuff */
    private Camera m_MainCamera;
    private Animator m_BlackScreenAnimator;
    private float m_Timer;
    private bool m_Start, m_Movement;

	void Start() 
    {
        m_MainCamera = Camera.main;
        m_MessageText.text = "";
        m_BlackScreenAnimator = m_BlackScreen.GetComponent<Animator>();
        m_Player.m_CanRun = false;
        m_Player.m_CanMove = false;

        m_MainCamera.orthographicSize = 1.5f;
        m_BlackScreenAnimator.Play("BlackScreenFadeOut");

        m_Start = false;
        m_Movement = false;
	}

	void Update() 
    {
        if (!m_Start)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_InactiveTime)
            {
                StartMovement();
            }
        }
        else if (!m_Movement)
        {
            InputText();
        }
	}

    void StartMovement()
    {
        m_Timer = 0.0f;
        m_Player.m_CanMove = true;
        m_Start = true;
    }

    void InputText()
    {
        if (m_MessageText.text != "Puedes desplazarte con A, W, S y D")
        {
            m_MessageText.text = "Puedes desplazarte con A, W, S y D";
        }    
        
        m_Timer += Time.deltaTime;
        if (m_Timer > m_InactiveTime)
        {
            m_MessageText.text = "";
            m_Movement = true;
        }
    }
}

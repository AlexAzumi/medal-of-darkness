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
    public float m_InactiveTime = 6f;

    /* Private stuff */
    private Camera m_MainCamera;
    private Animator m_BlackScreenAnimator;
    private Animator m_MessageTextAnimator;
    private float m_Timer;
    private bool m_Start, m_Movement;

	void Start() 
    {
        m_MainCamera = Camera.main;
        m_MessageText.text = "";
        m_BlackScreenAnimator = m_BlackScreen.GetComponent<Animator>();
        m_MessageTextAnimator = m_MessageText.GetComponent<Animator>();
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
                if (ChangeCameraSize(2.2f, 0.01f))
                {
                    m_Player.m_CanMove = true;
                    m_Timer = 0.0f;
                    m_Start = true;
                }
            }
        }
        else if (!m_Movement)
        {
            InputText();
        }
	}

    private bool ChangeCameraSize(float size, float vel)
    {
        if (m_MainCamera.orthographicSize.Equals(size))
            return true;
        else
        {
            float cameraSize = m_MainCamera.orthographicSize;
            //Debug.Log("Orthographic size = " + cameraSize);
            if (cameraSize < size)
                cameraSize += vel;
            if (cameraSize > size)
                cameraSize -= vel;

            m_MainCamera.orthographicSize = (float)System.Math.Round(cameraSize, 2);
            return false;
        }
    }
        
    private void InputText()
    {
        m_MessageText.text = "Puedes desplazarte con A, W, S y D";
        m_MessageTextAnimator.SetBool("isOnScreen", true);
  
        m_Timer += Time.deltaTime;
        if (m_Timer > m_InactiveTime)
        {
            m_MessageTextAnimator.SetBool("isOnScreen", false);
            m_Timer = 0.0f;
            m_Movement = true;
        }
    }

    public void SetMessageText(bool isOnTrigger, string text)
    {
        if (isOnTrigger)
        {
            
            if (!m_MessageText.text.Equals(text))
                m_MessageText.text = text;
                
            m_MessageTextAnimator.SetBool("isOnScreen", true);
        }
        else
            m_MessageTextAnimator.SetBool("isOnScreen", false);
    }

    public void PlayerCanRun(bool canRun)
    {
        m_Player.m_CanRun = canRun;
    }
}

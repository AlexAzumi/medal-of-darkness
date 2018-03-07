using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event01 : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public Image m_BlackScreen;
    public string m_InitialText = "Usa la palaca izq. para desplazarte";
    public float m_InactiveTime = 7f;

    /* Private stuff */
    private CameraControl m_CameraControl;
    private CharacterControl m_CharacterControl;
    private MessageText m_MessageText;
    private Animator m_BlackScreenAnimator;
    private float m_Timer;
    private bool m_Start, m_Movement;

	void Start() 
    {
        m_CameraControl = GetComponent<CameraControl>();
        m_CharacterControl = GetComponent<CharacterControl>();
        m_MessageText = GetComponent<MessageText>();
        m_BlackScreenAnimator = m_BlackScreen.GetComponent<Animator>();

        m_CharacterControl.SetCanMove(false);
        m_CharacterControl.SetCanRun(false);

        m_CameraControl.SetCameraSize(1.5f, false, 0.0f);
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
                if (m_CameraControl.SetCameraSize(2.5f, true, 0.01f))
                {
                    m_CharacterControl.SetCanMove(true);
                    m_Timer = 0.0f;
                    m_Start = true;
                }
            }
        }
        else if (!m_Movement)
        {
            InitialText();
        }
	} 
        
    private void InitialText()
    {
        m_MessageText.SetMessageText(m_InitialText, true);
  
        m_Timer += Time.deltaTime;
        if (m_Timer > m_InactiveTime)
        {
            m_MessageText.SetMessageText("", false);
            m_Timer = 0.0f;
            m_Movement = true;
        }
    }
}

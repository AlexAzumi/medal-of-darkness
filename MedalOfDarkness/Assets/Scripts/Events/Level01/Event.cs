using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public Image m_BlackScreen;
    public string m_InitialText = "Usa la palaca izq. para desplazarte";
    public float m_InactiveTime = 7f;
    public string[] m_InitialMessages = {"...", "¿Dónde estoy?...", "¿Quién soy?...", "¿Qué está sucediendo?..."};
    public string[] m_RockMessages = {"La roca está bloqueando el camino", "¿Qué hago ahora?"};

    /* Private stuff */
    private CameraControl m_CameraControl;
    private PlayerController m_CharacterControl;
    private MessageText m_MessageText;
    private DialogManager m_DialogManager;
    private Animator m_BlackScreenAnimator;
    private float m_Timer;
    private bool m_Start, m_InitialDialog, m_MovementMessage, m_Rock;

	void Start() 
    {
        m_CameraControl = GetComponent<CameraControl>();
        m_CharacterControl = GameObject.Find("Katherine").GetComponent<PlayerController>();
        m_MessageText = GetComponent<MessageText>();
        m_BlackScreenAnimator = m_BlackScreen.GetComponent<Animator>();
        m_DialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();

        m_CharacterControl.SetCanMove(false);
        m_CharacterControl.SetCanRun(false);

        m_CameraControl.SetCameraSize(1.5f, false, 0.0f);
        m_BlackScreenAnimator.Play("BlackScreenFadeOut");

        m_Start = false;
        m_InitialDialog = false;
        m_MovementMessage = false;
        m_Rock = false;
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
                    m_Timer = 0.0f;
                    m_Start = true;
                }
            }
        }
        else if (!m_InitialDialog)
        {
            m_DialogManager.SetMessageDialog(m_InitialMessages);
            m_InitialDialog = true;
        }
        if (m_CharacterControl.m_CanMove == true && !m_MovementMessage)
        {
            InitialText();
        }
        if (m_Rock)
        {
            m_DialogManager.SetMessageDialog(m_RockMessages);
            m_Rock = false;
        }
	} 
        
    /* Private methods */

    private void InitialText()
    {
        m_MessageText.SetMessageText(m_InitialText, true);
  
        m_Timer += Time.deltaTime;
        if (m_Timer > m_InactiveTime)
        {
            m_MessageText.SetMessageText("", false);
            m_Timer = 0.0f;
            m_MovementMessage = true;
        }
    }

    /* Public methods */

    public void SetMessages()
    {
        m_Rock = true;
    }
}

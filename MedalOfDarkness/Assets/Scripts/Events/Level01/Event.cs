using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public LoadMenuData m_Data;

    public Image m_BlackScreen;
    public GameObject m_PauseMenu;

    public string m_InitialText;
    public float m_InactiveTime = 7f;

    public string[] m_InitialMessages;
    public string[] m_RockMessages;
    public string m_RockInstruction;
    public string[] m_BarrelMessages;
    public string[] m_FoundOneBarrel;
    public string[] m_SolvedPuzzle;
    public string[] m_ExitMessages;

    public GameObject[] m_Buttons;
    public BoxCollider m_FocusTrigger;
    public MeshRenderer m_RockMesh;
    public SphereCollider m_RockCollider;

    /* Flags */
    public int m_ActualEvent = 0;
    public bool m_Found, m_Barrel01, m_Barrel02, m_Barrel03;
    public bool m_Solved;

    /* Private stuff */
    private CameraControl m_CameraControl;
    private PlayerController m_CharacterControl;
    private MessageText m_MessageText;
    private DialogManager m_DialogManager;
    private Animator m_BlackScreenAnimator;
    private float m_Timer;

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

        m_ActualEvent = 1;
        m_Found = false;
        m_Solved = false;
	}

	void Update() 
    {
        if (m_Barrel01 && m_Barrel02 && m_Barrel03)
        {
            m_ActualEvent = 6;
        }
        else if ((m_Barrel01 || m_Barrel02 || m_Barrel03) && !m_Found)
        {
            m_DialogManager.SetMessageDialog(m_FoundOneBarrel);
            m_Found = true;
        }

        if (m_ActualEvent == 1)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_InactiveTime)
            {
                if (m_CameraControl.SetCameraSize(2.5f, true, 0.01f))
                {
                    m_Timer = 0.0f;
                    m_ActualEvent = 2;
                }
            }
        }
        else if (m_ActualEvent == 2)
        {
            m_DialogManager.SetMessageDialog(m_InitialMessages);
            m_PauseMenu.SetActive(true);
            m_ActualEvent = 3;
        }
        else if (m_ActualEvent == 3 && m_CharacterControl.m_CanMove == true)
        {
            m_MessageText.ShowMessageInTime(m_InitialText, 7f);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 4)
        {
            m_DialogManager.SetMessageDialog(m_RockMessages);
            m_ActualEvent = 8;
        }
        else if (m_ActualEvent == 8 && m_CharacterControl.m_CanMove == true)
        {
            m_MessageText.ShowMessageInTime(m_RockInstruction, 7f);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 5)
        {
            m_DialogManager.SetMessageDialog(m_BarrelMessages);
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                m_Buttons[i].SetActive(true);
            }
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 6)
        {
            m_DialogManager.SetMessageDialog(m_SolvedPuzzle);
            m_FocusTrigger.enabled = true;
            m_RockMesh.enabled = false;
            m_RockCollider.enabled = false;
            m_Barrel01 = false;
            m_Barrel02 = false;
            m_Barrel03 = false;
            m_Solved = true;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 7)
        {
            m_DialogManager.SetMessageDialog(m_ExitMessages);
            m_ActualEvent = 0;
        }
	} 

    /* Public methods */

    public void SetMessages()
    {
        if (m_Solved)
        {
            m_ActualEvent = 7;
        }
        else
        {
            m_ActualEvent = 4;
        }
    }
}

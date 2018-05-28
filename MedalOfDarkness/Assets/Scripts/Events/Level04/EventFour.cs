using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFour : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public KaluMovement m_Kalu;
    public MessageText m_MessageText;
    public DialogManager m_DialogManager;
    public FocusObjectGeneric m_FocusObject, m_FocusObjectRockPuzzle;
    public Animator m_BlackScreenWin;

    public string[] m_SeenEnemy, m_LoseMessages, m_PuzzleMessagesOne, m_PuzzleMessagesTwo, m_SelectOptionMessages, m_RockDropMessages, m_BeforeRockMessages, m_BeforeTeleportMessages, m_CharlotteMessages;
    public string m_HideMessage;
    public float m_MessageTime;
    public GameObject[] m_HidePositions;
    public GameObject m_PuzzleMenu, m_Rock, m_VisibleRock;

    public bool m_Solved;

    private int m_ActualEvent;

    private void Start()
    {
        m_PauseMenu.SetActive(true);
        m_ActualEvent = 0;
        m_Solved = false;
    }

    private void Update()
    {
        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_SeenEnemy);
            m_ActualEvent = 2;
        }
        else if (m_ActualEvent == 2 && m_Katherine.m_CanMove)
        {
            ActivateColliders(true);
            m_MessageText.ShowMessageInTime(m_HideMessage, m_MessageTime);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 3)
        {
            if (m_HidePositions[0].GetComponent<BoxCollider>().enabled == false)
            {
                ActivateColliders(true);
            }
            m_DialogManager.SetMessageDialog(m_LoseMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 4)
        {
            ActivateColliders(false);
            m_DialogManager.SetMessageDialog(m_PuzzleMessagesOne);
            m_ActualEvent = 15;
        }
        else if (m_ActualEvent == 5 && m_Katherine.m_CanMove)
        {
            m_Katherine.m_CanMove = false;
            m_PuzzleMenu.SetActive(true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent >= 6 && m_ActualEvent <= 8)
        {
            m_DialogManager.SetMessageDialog(m_SelectOptionMessages);
            if (m_ActualEvent == 8)
            {
                m_Solved = true;
                Debug.Log("Solucionado");
            }
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 9)
        {
            m_DialogManager.SetMessageDialog(m_RockDropMessages);
            m_ActualEvent = 10;
        }
        else if (m_ActualEvent == 10 && m_Katherine.m_CanMove)
        {
            m_VisibleRock.SetActive(false);
            m_Rock.SetActive(true);
            m_FocusObject.FocusObject();
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 11)
        {
            m_DialogManager.SetMessageDialog(m_BeforeRockMessages);
            m_ActualEvent = 12;
        }
        else if (m_ActualEvent == 12 && m_Katherine.m_CanMove)
        {
            m_BlackScreenWin.SetBool("isActive", true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 13)
        {
            m_DialogManager.SetMessageDialog(m_BeforeTeleportMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 14)
        {
            m_DialogManager.SetMessageDialog(m_CharlotteMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 15 && m_Katherine.m_CanMove)
        {
            m_FocusObjectRockPuzzle.FocusObject();
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 16)
        {
            m_DialogManager.SetMessageDialog(m_PuzzleMessagesTwo);
            m_ActualEvent = 5;
        }
    }

    public void SetEvent(int opc)
    {
        m_ActualEvent = opc;
    }

    private void ActivateColliders(bool activate)
    {
        for (int i = 0; i < m_HidePositions.Length; i++)
        {
            m_HidePositions[i].GetComponent<BoxCollider>().enabled = activate;
        }
    }
}

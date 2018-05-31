using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EventFive : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public LevelScore m_LevelScore;
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public GameObject m_Kalu, m_KaluCopy, m_Charlotte;
    public MessageText m_MessageText;
    public DialogManager m_DialogManager;
    public GameObject m_BlackScreen;

    public Vector3 m_MoveKatherine;
    public BoxCollider m_ForceToTalk;
    public GameObject[] m_Exit;
    public FocusObjectGeneric m_FocusCharlotte, m_FocusKaluCopy;

    public string[] m_MenMessages, m_WatchKhrix, m_WatchCharlotte, m_TalkWithCharlotteOne, m_TalkWithCharlotteTwo, m_Puzzle, m_ForceTalkWithMen, m_CantExit, m_SearchMayor;

    private int m_ActualEvent;

    private void Start()
    {
        try
        {
            m_LevelScore = GameObject.FindGameObjectWithTag("LevelScore").GetComponent<LevelScore>();
        }
        catch(NullReferenceException ex)
        {
            Debug.LogWarning("Score Manager not found > " + ex.Message);
        }
        m_ActualEvent = 0;
    }

    private void Update()
    {
        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_MenMessages);
            m_ActualEvent = 11;
        }
        else if (m_ActualEvent == 2)
        {
            m_DialogManager.SetMessageDialog(m_WatchKhrix);
            m_ActualEvent = 3;
        }
        else if (m_ActualEvent == 3 && m_Katherine.m_CanMove)
        {
            m_FocusCharlotte.FocusObject();
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 4)
        {
            m_DialogManager.SetMessageDialog(m_WatchCharlotte);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 5)
        {
            m_DialogManager.SetMessageDialog(m_TalkWithCharlotteOne);
            m_ActualEvent = 6;
        }
        else if (m_ActualEvent == 6 && m_Katherine.m_CanMove)
        {
            m_KaluCopy.GetComponent<KaluMovement>().FollowKatherine();
            m_DialogManager.SetMessageDialog(m_TalkWithCharlotteTwo);
            m_ActualEvent = 7;
        }
        else if (m_ActualEvent == 7 && m_Katherine.m_CanMove)
        {
            m_KaluCopy.GetComponent<Animator>().SetTrigger("disappear");
            m_FocusKaluCopy.FocusObject();
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 8)
        {
            m_DialogManager.SetMessageDialog(m_Puzzle);
            m_ActualEvent = 13;
        }
        else if (m_ActualEvent == 9)
        {
            m_DialogManager.SetMessageDialog(m_ForceTalkWithMen);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 10)
        {
            m_Katherine.MoveRigidbody(m_MoveKatherine);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 11 && m_Katherine.m_CanMove)
        {
            m_ForceToTalk.enabled = false;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 12)
        {
            m_DialogManager.SetMessageDialog(m_CantExit);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 13 && m_Katherine.m_CanMove)
        {
            m_Katherine.m_CanMove = false;
            m_BlackScreen.GetComponent<Animator>().SetBool("isActive", true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 14 && m_BlackScreen.GetComponent<Image>().color.a == 1.0f)
        {
            m_Charlotte.SetActive(false);
            m_ActualEvent = 15;
        }
        else if (m_ActualEvent == 15 && m_BlackScreen.GetComponent<Image>().color.a == 0.0f)
        {
            m_DialogManager.SetMessageDialog(m_SearchMayor);
            m_ActualEvent = 0;
        }
    }

    public void UnlockExit()
    {
        for (int i = 0; i < m_Exit.Length; i++)
        {
            m_Exit[i].SetActive(false);
        }
    }

    public void SetEvent(int opc)
    {
        m_ActualEvent = opc;
    }
}

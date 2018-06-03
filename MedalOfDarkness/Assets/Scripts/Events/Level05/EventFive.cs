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
    public Light[] m_LanternsLight;
    public BoxCollider[] m_LanternsColliders;
    public Transform m_Mayor, m_NewMayorPosition;
    public Transform m_NewKatherinePosition;

    public string[] m_MenMessages, m_WatchKhrix, m_WatchCharlotte, m_TalkWithCharlotteOne, m_TalkWithCharlotteTwo, m_TalkWithCharlotteThree, m_ForceTalkWithMen, m_CantExit, m_SearchMayor, m_Puzzle, m_Error, m_Complete, m_Thanks;

    private int[] m_LanterNum;
    private int m_ActualEvent, m_LanternsOrder;

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
        m_LanternsOrder = 0;
        m_LanterNum = new int[4];
    }

    private void Update()
    {
        if (m_LanternsOrder > 3)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (m_LanterNum[i] == i)
                {
                    count++;
                }
            }
            if (count == 4)
            {
                m_LanternsOrder = 0;
                m_ActualEvent = 21;
            }
            else
            {
                m_LanternsOrder = 0;
                m_ActualEvent = 20;
            }
        }

        if (m_ActualEvent == 1 && m_Charlotte.activeSelf)
        {
            m_DialogManager.SetMessageDialog(m_MenMessages);
            m_ActualEvent = 11;
        }
        else if (m_ActualEvent == 1 && !m_Charlotte.activeSelf)
        {
            for (int i = 0; i < m_LanternsColliders.Length; i++)
            {
                if (!m_LanternsColliders[i].enabled)
                {
                    m_LanternsColliders[i].enabled = true;
                }
            }
            m_LevelScore.StartPuzzle();
            m_DialogManager.SetMessageDialog(m_Puzzle);
            m_ActualEvent = 0;
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
            m_DialogManager.SetMessageDialog(m_TalkWithCharlotteThree);
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
        else if (m_ActualEvent == 16)
        {
            m_LanternsColliders[0].enabled = false;
            m_LanternsLight[0].enabled = false;
            m_LanterNum[0] = m_LanternsOrder;
            m_LanternsOrder++;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 17)
        {
            m_LanternsColliders[1].enabled = false;
            m_LanternsLight[1].enabled = false;
            m_LanterNum[1] = m_LanternsOrder;
            m_LanternsOrder++;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 18)
        {
            m_LanternsColliders[2].enabled = false;
            m_LanternsLight[2].enabled = false;
            m_LanterNum[2] = m_LanternsOrder;
            m_LanternsOrder++;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 19)
        {
            m_LanternsColliders[3].enabled = false;
            m_LanternsLight[3].enabled = false;
            m_LanterNum[3] = m_LanternsOrder;
            m_LanternsOrder++;
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 20)
        {
            for (int i = 0; i < m_LanternsLight.Length; i++)
            {
                m_LanternsLight[i].enabled = true;
                m_LanternsColliders[i].enabled = true;
            }
            m_DialogManager.SetMessageDialog(m_Error);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 21)
        {
            m_LevelScore.StopPuzzle();
            m_DialogManager.SetMessageDialog(m_Complete);
            m_ActualEvent = 22;
        }
        else if (m_ActualEvent == 22 && m_Katherine.m_CanMove)
        {
            m_Katherine.m_CanMove = false;
            m_BlackScreen.GetComponent<LoseScriptGeneric>().m_NewPosition = m_NewKatherinePosition;
            m_BlackScreen.GetComponent<LoseScriptGeneric>().m_CallEvent = 23;
            m_BlackScreen.GetComponent<Animator>().SetBool("isActive", true);
            m_ActualEvent = 23;
        }
        else if (m_ActualEvent == 23 && m_BlackScreen.GetComponent<Image>().color.a == 1.0f)
        {
            m_ForceToTalk.enabled = false;
            m_Mayor.position = m_NewMayorPosition.position;
            m_Mayor.rotation = m_NewMayorPosition.rotation;
            m_ActualEvent = 24;
        }
        else if (m_ActualEvent == 24 && m_BlackScreen.GetComponent<Image>().color.a == 0.0f)
        {
            for (int i = 0; i < m_Exit.Length; i++)
            {
                m_Exit[i].GetComponent<BoxCollider>().enabled = false;
            }
            m_DialogManager.SetMessageDialog(m_Thanks);
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

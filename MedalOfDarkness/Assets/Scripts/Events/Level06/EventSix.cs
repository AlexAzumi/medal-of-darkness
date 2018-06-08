using System.Collections;
using UnityEngine;
using System;

public class EventSix : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public LevelScore m_LevelScore;
    public int m_RemovePoints = 120;
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public GameObject m_Kalu;
    public MessageText m_MessageText;
    public DialogManager m_DialogManager;
    public GameObject m_BlackScreen;
    public GameObject m_PuzzleScreenOne, m_PuzzleScreenTwo;
    public BoxCollider m_PuzzleTriggerOne;
    public GameObject[] m_Enemies;
    public GameObject m_FocusEnemiesOne;
    public Animator m_LastHope;
    public BoxCollider m_KhrixTrigger;
    public Animator m_Khrix;
    public AudioSource m_BGM;
    public AudioClip m_FinalSong;
    public Transform m_FlyKalu;
    public Animator m_BetweeScenes;

    public string[] m_WatchEnemiesOne, m_FailMessages, m_ReachKhrix, m_LastHopeMessages, m_FailLastHope, m_LastHopeCompleted, m_BeforeKhrix, m_ByeMessages, m_LetsGoHome;

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
            m_LevelScore.StartPuzzle();
            m_DialogManager.SetMessageDialog(m_WatchEnemiesOne);
            m_ActualEvent = 2;
        }
        else if (m_ActualEvent == 2 && m_Katherine.m_CanMove)
        {
            m_PauseMenu.SetActive(false);
            m_Katherine.m_CanMove = false;
            m_PuzzleScreenOne.SetActive(true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 3)
        {
            m_LevelScore.RemovePoints(m_RemovePoints);
            m_PauseMenu.SetActive(true);
            m_BlackScreen.GetComponent<Animator>().SetBool("isActive", true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 4)
        {
            m_PauseMenu.SetActive(true);
            m_PuzzleTriggerOne.enabled = false;
            m_FocusEnemiesOne.GetComponent<FocusObjectGeneric>().FocusObject();
            for (int i = 0; i < m_Enemies.Length; i++)
            {
                m_Enemies[i].GetComponent<Animator>().SetTrigger("disappear");
            }
        }
        else if (m_ActualEvent == 5)
        {
            m_DialogManager.SetMessageDialog(m_FailMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 6)
        {
            m_DialogManager.SetMessageDialog(m_ReachKhrix);
            m_ActualEvent = 7;
        }
        else if (m_ActualEvent == 7 && m_Katherine.m_CanMove)
        {
            m_PauseMenu.SetActive(false);
            m_Katherine.m_CanMove = false;
            m_LastHope.SetTrigger("start");
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 8)
        {
            m_PauseMenu.SetActive(true);
            m_DialogManager.SetMessageDialog(m_LastHopeMessages);
            m_ActualEvent = 9;
        }
        else if (m_ActualEvent == 9 && m_Katherine.m_CanMove)
        {
            m_PauseMenu.SetActive(false);
            m_Katherine.m_CanMove = false;
            m_PuzzleScreenTwo.SetActive(true);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 10)
        {
            m_LevelScore.RemovePoints(m_RemovePoints);
            m_PauseMenu.SetActive(true);
            m_DialogManager.SetMessageDialog(m_FailLastHope);
            m_ActualEvent = 9;
        }
        else if (m_ActualEvent == 11)
        {
            m_LevelScore.StopPuzzle();
            m_KhrixTrigger.enabled = false;
            m_PauseMenu.SetActive(true);
            m_DialogManager.SetMessageDialog(m_LastHopeCompleted);
            m_ActualEvent = 12;
        }
        else if (m_ActualEvent == 12 && m_Katherine.m_CanMove)
        {
            m_Katherine.m_CanMove = false;
            m_Khrix.SetTrigger("disappear");
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 13)
        {
            m_BGM.Stop();
            m_BGM.clip = m_FinalSong;
            m_BGM.Play();
            m_DialogManager.SetMessageDialog(m_BeforeKhrix);
            m_ActualEvent = 14;
        }
        else if (m_ActualEvent == 14 && m_Katherine.m_CanMove)
        {
            m_Kalu.GetComponent<KaluMovement>().m_Katherine = m_FlyKalu;
            m_DialogManager.SetMessageDialog(m_ByeMessages);
            m_ActualEvent = 15;
        }
        else if (m_ActualEvent == 15 && m_Katherine.m_CanMove)
        {
            m_LevelScore.SubmitScore();
            m_DialogManager.SetMessageDialog(m_LetsGoHome);
            m_ActualEvent = 16;
        }
        else if (m_ActualEvent == 16 && m_Katherine.m_CanMove)
        {
            m_Katherine.m_CanMove = false;
            m_BetweeScenes.SetTrigger("fadeOut");
            m_ActualEvent = 0;
        }
    }

    public void SetEvent(int opc)
    {
        m_ActualEvent = opc;
    }
}

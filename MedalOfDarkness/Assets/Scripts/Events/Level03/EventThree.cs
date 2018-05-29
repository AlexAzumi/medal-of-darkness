using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventThree : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public LevelScore m_LevelScore;
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public KaluMovement m_Kalu;
    public FocusObjectThree m_Focus;
    public MessageText m_MessageText;
    public MoveObject m_Wall;
    public PaperText m_Paper;

    public Transform m_FocusDoor;
    public BoxCollider[] m_Switches;
    public string m_ReopenPage;
    public float m_MessageDuration;
    public string[] m_EntranceMessages, m_FoundPaper, m_PaperText, m_FailedMessages, m_ResolvedMessages;

    private DialogManager m_DialogManager;
    private int m_ActualEvent = 0;

    private int switchOne, switchTwo, switchThree, switchFour, switchCount;
    private bool canRead, resolved;

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
        m_DialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        m_PauseMenu.SetActive(true);
        m_Kalu.FollowKatherine();
        resolved = false;
        canRead = false;
        switchOne = 0;
        switchTwo = 0;
        switchThree = 0;
        switchFour = 0;
        switchCount = 0;
	}

	private void Update() 
    {
        if (switchCount > 3 && !resolved)
        {
            m_DialogManager.SetMessageDialog(m_FailedMessages);
            switchCount = 0;
            switchOne = 0;
            switchTwo = 0;
            switchThree = 0;
            switchFour = 0;
        }

        if (canRead && (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.Q)))
        {
            m_Paper.ShowPaper(m_PaperText);
        }

        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_EntranceMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 2)
        {
            m_DialogManager.SetMessageDialog(m_FoundPaper);
            m_ActualEvent = 3;
        }
        else if (m_ActualEvent == 3 && m_Katherine.m_CanMove)
        {
            for (int i = 0; i < m_Switches.Length; i++)
            {
                m_Switches[i].enabled = true;
            }
            m_Paper.ShowPaper(m_PaperText);
            m_ActualEvent = 5;
        }
        else if (m_ActualEvent == 4)
        {
            m_LevelScore.StopPuzzle();
            for (int i = 0; i < m_Switches.Length; i++)
            {
                m_Switches[i].enabled = false;
            }
            m_DialogManager.SetMessageDialog(m_ResolvedMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 5 && m_Katherine.m_CanMove)
        {
            m_LevelScore.StartPuzzle();
            m_MessageText.ShowMessageInTime(m_ReopenPage, m_MessageDuration);
            canRead = true;
            m_ActualEvent = 0;
        }
	}

    /* Public methods */
    public void SetEvent(int opc)
    {
        m_ActualEvent = opc;
    }

    public void SetSwitch(int switchNum)
    {
        switch (switchNum)
        {
            case 1:
                switchOne = switchCount;
                Debug.Log("switchOne = " + switchCount);
                break;
            case 2:
                switchTwo = switchCount;
                Debug.Log("switchTwo = " + switchCount);
                break;
            case 3:
                switchThree = switchCount;
                Debug.Log("switchThree = " + switchCount);
                break;
            case 4:
                switchFour = switchCount;
                Debug.Log("switchFour = " + switchCount);
                break;
        }
      
        if (switchTwo == 0 && switchThree == 1 && switchFour == 2 && switchOne == 3)
        {
            resolved = true;
            m_MessageText.SetMessageText("", false);
            m_Focus.FocusObject(m_FocusDoor);
            m_Wall.Move();
        }
        switchCount++;
    }
}

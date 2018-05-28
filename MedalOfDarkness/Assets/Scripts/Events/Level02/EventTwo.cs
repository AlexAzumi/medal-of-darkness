using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTwo : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public KaluMovement m_Kalu;

    public string[] m_KaluMessages;
    public string[] m_PuzzleMessages;
    public string[] m_FailMessages;
    public string[] m_RestartMessages;
    public string[] m_CompleteMessages;
    public string[] m_KatherineInfo;

    /* Private stuff */
    private DialogManager m_DialogManager;
    private LoseScript m_Lose;
    private int m_ActualEvent = 0;

	private void Start()
    {
        m_DialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        m_PauseMenu.SetActive(true);

        m_Lose = gameObject.GetComponent<LoseScript>();
	}

	private void Update()
    {
        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_KaluMessages);
            m_ActualEvent = 2;
        }
        else if (m_ActualEvent == 2 && m_Katherine.m_CanMove)
        {
            m_Kalu.FollowKatherine();
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 3)
        {
            m_DialogManager.SetMessageDialog(m_PuzzleMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 4)
        {
            m_DialogManager.SetMessageDialog(m_FailMessages);
            m_ActualEvent = 5;
        }
        else if (m_ActualEvent == 5 && m_Katherine.m_CanMove)
        {
            m_Lose.Restart();
            m_ActualEvent = 7;
        }
        else if (m_ActualEvent == 7 && m_Katherine.m_CanMove)
        {
            m_DialogManager.SetMessageDialog(m_RestartMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 6)
        {
            m_DialogManager.SetMessageDialog(m_CompleteMessages);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 8)
        {
            m_DialogManager.SetMessageDialog(m_KatherineInfo);
            m_ActualEvent = 0;
        }
	}

    /* Public methods */
    public void SetMessages(int opc)
    {
        m_ActualEvent = opc;
    }
}

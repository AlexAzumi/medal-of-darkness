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

    public string[] m_SeenEnemy, m_LoseMessages;

    public bool solved;

    private int m_ActualEvent;

    private void Start()
    {
        m_PauseMenu.SetActive(true);
        m_ActualEvent = 0;
        solved = false;
    }

    private void Update()
    {
        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_SeenEnemy);
            m_ActualEvent = 0;
        }
        else if (m_ActualEvent == 2)
        {
            m_DialogManager.SetMessageDialog(m_LoseMessages);
            m_ActualEvent = 0;
        }
    }

    public void SetEvent(int opc)
    {
        m_ActualEvent = opc;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFive : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public KaluMovement m_Kalu;
    public MessageText m_MessageText;
    public DialogManager m_DialogManager;

    private void Start()
    {
        m_PauseMenu.SetActive(true);
    }
}

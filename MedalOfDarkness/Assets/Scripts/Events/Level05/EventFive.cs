using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventFive : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public LevelScore m_LevelScore;
    public GameObject m_PauseMenu;
    public PlayerController m_Katherine;
    public KaluMovement m_Kalu;
    public MessageText m_MessageText;
    public DialogManager m_DialogManager;


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
    }
}

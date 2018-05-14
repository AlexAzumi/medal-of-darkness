using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game 
{
    /* Made by Aldan Project | 2018 */
    private string m_User;
    private int m_Score;
    private int m_ActualScene;
    private int m_Time;
    private Transform m_Position;

    /* Level 01 */
    public int m_ActualEvent01;
    public bool m_RockEvent01;
    public bool m_BarrelEvent01;
    public bool m_Barrel01, m_Barrel02, m_Barrel03;
    public bool m_Solved01;

    public Game(string user, int score, int time)
    {
        m_User = user;
        m_Score = score;
        m_Time = time;
        m_ActualScene = 1;

        m_ActualEvent01 = 0;
        m_Solved01 = false;
    }

    /* Set values */
    public void SetScore(int score)
    {
        m_Score = score;
    }

    public void SetActualScene(int scene)
    {
        m_ActualScene = scene;
    }

    public void SetActualPosition(Transform position)
    {
        m_Position = position;
    }

    public void SetLevel01(int actualEvent, bool rockEvent, bool barrelEvent, bool barrel01, bool barrel02, bool barrel03, bool solved)
    {
        m_ActualEvent01 = actualEvent;
        m_RockEvent01 = rockEvent;
        m_BarrelEvent01 = barrelEvent;
        m_Barrel01 = barrel01;
        m_Barrel02 = barrel02;
        m_Barrel03 = barrel03;
    }

    /* Get values */
    public string GetUsername()
    {
        return m_User;
    }

    public int GetTime()
    {
        return m_Time;
    }

    public int GetScore()
    {
        return m_Score;
    }

    public int GetActualScene()
    {
        return m_ActualScene;
    }

    public Transform GetActualPosition()
    {
        return m_Position;
    }
}

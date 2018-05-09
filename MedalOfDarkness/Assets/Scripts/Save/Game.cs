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

    public Game(string user, int score, int time)
    {
        this.m_User = user;
        this.m_Score = score;
        this.m_Time = time;
        this.m_ActualScene = 1;
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

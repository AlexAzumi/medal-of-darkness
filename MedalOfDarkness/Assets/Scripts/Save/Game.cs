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
    private Transform m_Position;

    public Game(string user, int score)
    {
        this.m_User = user;
        this.m_Score = score;
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

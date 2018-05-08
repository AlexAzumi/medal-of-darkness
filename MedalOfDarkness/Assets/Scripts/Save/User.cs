using System.Collections;
using UnityEngine;

[System.Serializable]
public class User
{
    /* Made by Aldan Project | 2018 */
    public string m_Username;
    public int m_Score;

    public User(string username, int score)
    {
        this.m_Username = username;
        this.m_Score = score;
    }
}

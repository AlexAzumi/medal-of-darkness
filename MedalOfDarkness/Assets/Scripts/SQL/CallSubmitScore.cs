using UnityEngine;
using System;

public class CallSubmitScore : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public bool m_Publish = false;

    private LevelScore m_LevelScore;

    private void Start()
    {
        try
        {
            m_LevelScore = GameObject.FindGameObjectWithTag("LevelScore").GetComponent<LevelScore>();
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("Mensaje: " + ex.Message);
            Debug.Log("ScoreManager no existe");
        }
    }

    public void SubmitScore()
    {
        if (m_Publish)
        {
            m_LevelScore.SubmitScore();
        }
    }
}
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
            Debug.LogWarning("Score Manager not found (CallSubmitScore) > " + ex.Message);
        }
    }

    public void SubmitScore()
    {
        if (m_Publish)
        {
            try
            {
                m_LevelScore.SubmitScore();
            }
            catch(NullReferenceException ex) 
            {
                Debug.LogWarning("Error while sending username to Score Manager > " + ex.Message);
            }
        }
    }
}
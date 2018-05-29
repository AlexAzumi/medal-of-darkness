using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScoreManager : MonoBehaviour 
{
    private void Start()
    {
        GameObject m_ScoreManger = GameObject.FindGameObjectWithTag("LevelScore");
        if (m_ScoreManger != null)
        {
            Destroy(m_ScoreManger);
            Debug.Log("Score Manager was deleted from this scene");
        }
    }
}

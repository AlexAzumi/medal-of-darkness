using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public Text m_MessageText;

    /* Private stuff */
    private Animator m_Animator;
    private float m_Timer;
    private float m_WaitTime;
    private bool m_OnUse, m_Showing = false;

    void Start()
    {
        m_Animator = m_MessageText.GetComponent<Animator>();
        m_Timer = 0.0f;
        m_WaitTime = 0.0f;
        m_OnUse = false;
    }

    void Update()
    {
        if (m_OnUse)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_WaitTime)
            {
                SetMessageText("", false);
                m_Timer = 0.0f;
                m_WaitTime = 0.0f;
                m_OnUse = false;
            }
        }
    }

    public void SetMessageText(string text, bool onTrigger)
    {
        try
        {
            if (onTrigger)
            {
                m_MessageText.text = text;
                if(!m_Showing)
                {
                    m_Animator.SetBool("isOnScreen", true);
                    m_Showing = true;
                }
            }
            else
            {
                m_Animator.SetBool("isOnScreen", false);
                m_Showing = false;
            }
        }
        catch(MissingReferenceException ex)
        {
            Debug.Log("Animator not found > " + ex.Message);
        }
    }

    public void ShowMessageInTime(string text, float time)
    {
        m_Timer = 0f;
        m_WaitTime = time;
        m_OnUse = true;
        SetMessageText(text, true);
    }
}

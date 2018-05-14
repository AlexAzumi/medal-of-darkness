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
    private bool m_OnUse;

    void Start()
    {
        m_Animator = m_MessageText.GetComponent<Animator>();
        m_Timer = 0.0f;
        m_WaitTime = 0.0f;
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
        if (onTrigger && !m_OnUse)
        {
            m_Timer = 0f;
            if (!m_MessageText.text.Equals(text))
                m_MessageText.text = text;

            m_Animator.SetBool("isOnScreen", true);
        }
        else
            m_Animator.SetBool("isOnScreen", false);
    }

    public void ShowMessageInTime(string text, float time)
    {
        SetMessageText(text, true);
        m_WaitTime = time;
        m_OnUse = true;
    }
}

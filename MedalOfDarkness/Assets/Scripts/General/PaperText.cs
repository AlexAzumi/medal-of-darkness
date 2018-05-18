using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperText : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Text m_Text;
    public Animator m_Animator;

    public void ShowPaper(string[] text)
    {
        m_Text.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            m_Text.text += text[i];
            if (i + 1 < text.Length)
            {
                m_Text.text += "\n";
            }
        }
        m_Animator.SetBool("isShowing", true);
    }

    public void HidePaper()
    {
        m_Animator.SetBool("isShowing", false);
    }
}

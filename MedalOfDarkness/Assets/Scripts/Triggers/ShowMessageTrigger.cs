using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessageTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string m_Text = "Presiona E para abrir";
    public string m_ActionText = "La puerta está cerrada";

    /* Private stuff */
    private Event01 m_Event01;


    void Start()
    {
        m_Event01 = GameObject.Find("GameManager").GetComponent<Event01>();
    }
        
    void OnTriggerEnter()
    {
        m_Event01.SetMessageText(true, m_Text);
    }

    void OnTriggerExit()
    {
        m_Event01.SetMessageText(false, m_Text);
    }

    void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0)
            m_Event01.SetMessageText(true, m_ActionText);
    }
}


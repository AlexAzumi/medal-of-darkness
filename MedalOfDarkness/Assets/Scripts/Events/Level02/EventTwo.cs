using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTwo : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public GameObject m_PauseMenu;
    public string[] m_KaluMessages;

    /* Private stuff */
    private int m_ActualEvent = 0;
    private DialogManager m_DialogManager;

	private void Start()
    {
        m_DialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        m_PauseMenu.SetActive(true);
	}

	private void Update()
    {
        if (m_ActualEvent == 1)
        {
            m_DialogManager.SetMessageDialog(m_KaluMessages);
            m_ActualEvent = 0;
        }
	}

    /* Public methods */
    public void SetMessages()
    {
        
    }
}

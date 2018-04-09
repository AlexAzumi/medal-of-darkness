using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTwo : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string[] m_KaluMessages;

    /* Private stuff */
    private bool m_ReachedKalu;
    private DialogManager m_DialogManager;

	private void Start()
    {
        m_DialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        m_ReachedKalu = false;
	}
	private void Update()
    {
        if (m_ReachedKalu)
        {
            m_DialogManager.SetMessageDialog(m_KaluMessages);
            m_ReachedKalu = false;
        }
	}

    /* Public methods */
    public void SetMessages()
    {
        m_ReachedKalu = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_Trigger;

    private void OnTriggerEnter()
    {
        m_Trigger.SetActive(true);
    }
}

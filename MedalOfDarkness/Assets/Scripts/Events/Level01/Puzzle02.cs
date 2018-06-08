using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle02 : MonoBehaviour 
{
    /* Made by Aldan Project */
    public Event m_Event;

    private void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0)
        {
            string name = this.name;
            if (name.Contains("01"))
            {
                m_Event.m_Barrel01 = true;
            }
            else if (name.Contains("02"))
            {
                m_Event.m_Barrel02 = true;
            }
            else if (name.Contains("03"))
            {
                m_Event.m_Barrel03 = true;
            }
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

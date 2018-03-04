using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovement : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public bool m_PlayerCanRun = true;
    public string m_Text = "Presiona Shift para correr";

    /* Private stuff */
    private CharacterControl m_CharacterControl;
    private MessageText m_MessageText;

    void Start()
    {
        m_CharacterControl = GameObject.Find("GameManager").GetComponent<CharacterControl>();
        m_MessageText = GameObject.Find("GameManager").GetComponent<MessageText>();
    }

    void OnTriggerEnter()
    {
        m_CharacterControl.SetCanRun(true);
        m_MessageText.ShowMessageInTime(m_Text, 5.0f);
        GetComponent<BoxCollider>().enabled = false;
    }
}

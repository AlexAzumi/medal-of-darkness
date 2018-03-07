using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_DialogBox;
    public Text m_DialogText;

    /* Private stuff */
    private CharacterControl m_CharacterControl;
    private bool m_Active;

	private void Start() 
    {
        m_CharacterControl = GameObject.Find("GameManager").GetComponent<CharacterControl>();
	}
	
	private void Update() 
    {
        if (m_Active && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            m_DialogBox.SetActive(false);
            m_Active = false;
            m_CharacterControl.m_Player.m_CanMove = true;
        }
	}

    public void SetMessageDialog(string dialogText)
    {
        m_CharacterControl.m_Player.m_CanMove = false;
        m_DialogText.text = dialogText;
        m_Active = true;
        m_DialogBox.SetActive(true);
    }
}

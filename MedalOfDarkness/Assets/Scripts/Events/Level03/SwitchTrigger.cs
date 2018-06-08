using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */   
    public EventThree eventThree;
    public MessageText messageText;
    public int switchNumber;
    public string enterMessage;
    public string actionMessage;

    private void OnTriggerEnter()
    {
        messageText.SetMessageText(enterMessage, true);
    }

    private void OnTriggerExit()
    {
        messageText.SetMessageText("", false);
    }

	private void OnTriggerStay()
    {
        if (Input.GetButtonDown("Action"))
        {
            messageText.SetMessageText(actionMessage, true);
            eventThree.SetSwitch(switchNumber);
        }
	}
}

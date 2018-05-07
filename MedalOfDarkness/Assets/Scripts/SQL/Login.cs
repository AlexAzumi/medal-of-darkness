using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string m_LoginURL;
    public InputField m_Username;
    public InputField m_Password;

	public void LoginNow() 
    {
        string username = m_Username.text;
        string password = m_Password.text;
        StartCoroutine(login(username, password));
	}

    private IEnumerator login(string username, string password)
    {
        //Debug.Log(username);
        //Debug.Log(password);
        WWWForm login = new WWWForm();
        login.AddField("action", "login");
        login.AddField("username", username);
        login.AddField("password", password);
        WWW sendData = new WWW(m_LoginURL, login);
        yield return sendData;
        Debug.Log(sendData.text);
    }
}

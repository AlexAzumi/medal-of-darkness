using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string m_LoginURL = "https://aldanproject.000webhostapp.com/unity-scripts/login.php";
    public InputField m_Username;
    public InputField m_Password;
    public string m_ServerError = "Se ha generado un problema en el servidor";
    public string m_Incorrect = "Datos incorrectos";
    public Text m_Message;
    public Animator m_BetweenScenes;
    public EventSystem m_EventSystem;

    /* Private stuff */
    private string m_Result;
    private User m_User;
    private SaveLoad m_SaveLoad;

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
        login.AddField("username", username);
        login.AddField("password", password);
        WWW sendData = new WWW(m_LoginURL, login);
        yield return sendData;
        string result = sendData.text;
        Debug.Log(sendData.text);
        if (result != null && result != "")
        {
            if (result.Contains("Error"))
            {
                if (result.Contains("01"))
                {
                    m_Message.text = m_ServerError;
                }
                else if (result.Contains("02"))
                {
                    m_Message.text = m_Incorrect;
                }
                Color color = m_Message.color;
                color.a = 1;
                m_Message.color = color;
            }
            else
            {
                Debug.Log("Guardando usuario...");
                string[] data = result.Split('|');
                m_User = new User(data[0], int.Parse(data[1]));
                m_SaveLoad = new SaveLoad();
                m_SaveLoad.m_User = m_User;
                m_SaveLoad.SaveUser();
                Debug.Log("Usuario guardado");
                m_EventSystem.enabled = false;
                m_BetweenScenes.SetTrigger("fadeOut");
            }
        }
        else
        {
            m_Message.text = m_ServerError;
            Color color = m_Message.color;
            color.a = 1;
            m_Message.color = color;
        }
    }
}

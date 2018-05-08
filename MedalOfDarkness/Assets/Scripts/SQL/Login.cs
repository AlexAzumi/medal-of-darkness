using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public string m_LoginURL;
    public InputField m_Username;
    public InputField m_Password;

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
        login.AddField("action", "login");
        login.AddField("username", username);
        login.AddField("password", password);
        WWW sendData = new WWW(m_LoginURL, login);
        yield return sendData;
        string result = sendData.text;
        Debug.Log(sendData.text);
        if (result != null)
        {
            Debug.Log("Guardando usuario...");
            string[] data = result.Split('|');
            m_User = new User(data[0], int.Parse(data[1]));
            m_SaveLoad = new SaveLoad();
            m_SaveLoad.m_User = m_User;
            m_SaveLoad.SaveUser();
            Debug.Log("Usuario guardado");
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("Level01");

        while (!load.isDone)
        {
            yield return null;
        }
    }
}

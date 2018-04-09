using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    public void LoadSceneCall()
    {
        StartCoroutine(LoadScene());
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

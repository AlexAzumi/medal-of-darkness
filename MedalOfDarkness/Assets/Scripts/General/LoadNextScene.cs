using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour 
{
    public string sceneName;

    private void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0)
        {
            LoadSceneNow();
        }
    }

    public void LoadSceneNow()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);

        while (!load.isDone)
        {
            yield return null;
        }
    }
}

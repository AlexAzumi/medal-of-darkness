using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    public string sceneName;

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

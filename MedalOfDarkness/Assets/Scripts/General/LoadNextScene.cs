using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextScene : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Animator animator;
    public AudioSource audioSource;
    public int secondsToFade = 1;

    private bool fadeOut = false;

    private void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0)
        {
            animator.SetTrigger("fadeOut");
            fadeOut = true;
        }
    }

    private void FixedUpdate()
    {
        if (fadeOut)
        {
            if (audioSource.volume > 0)
            {
                audioSource.volume -= (Time.deltaTime / (secondsToFade + 1));
            }
            else
            {
                Destroy(this);
            }
        }
    }
}


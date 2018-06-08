using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextScene : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public Animator animator;
    public AudioSource audioSource;
    public int secondsToFade = 1;
    public GameObject m_PauseMenu;
    public GameObject m_Katherine;

    private bool fadeOut = false;

    private void OnTriggerStay()
    {
        if (Input.GetAxisRaw("Action") != 0 && !fadeOut)
        {
            LoadScene();
        }
    }

    private void Update()
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

    public void LoadScene()
    {
        fadeOut = true;
        m_PauseMenu.SetActive(false);
        m_Katherine.GetComponent<PlayerController>().m_CanMove = false;
        m_Katherine.GetComponent<Animator>().SetBool("IsWalking", false);
        m_Katherine.GetComponent<Animator>().SetBool("IsRunning", false);
        animator.SetTrigger("fadeOut");
    }
}


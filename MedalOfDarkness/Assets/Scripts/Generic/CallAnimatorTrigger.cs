using System.Collections;
using UnityEngine;

public class CallAnimatorTrigger : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_Anim;
    public string m_Trigger;

    public void OnTriggerEnter()
    {
        m_Anim.GetComponent<Animator>().SetTrigger(m_Trigger);
    }
}

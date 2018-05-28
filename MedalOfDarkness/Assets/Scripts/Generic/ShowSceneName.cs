using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSceneName : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_SceneName;

    public void ShowName()
    {
        try
        {
            m_SceneName.GetComponent<Animator>().SetTrigger("showName");
        }
        catch(UnassignedReferenceException ex)
        {
            Debug.Log("Mensaje: " + ex.Message);
            Debug.Log("Sin nombre de escena");
        }
    }
}

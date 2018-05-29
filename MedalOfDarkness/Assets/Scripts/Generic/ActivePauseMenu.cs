using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePauseMenu : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public GameObject m_PauseMenu;

    public void ActiveMenu()
    {
        try
        {
            m_PauseMenu.SetActive(true);
        }
        catch(UnassignedReferenceException ex)
        {
            Debug.LogWarning("Menu not assigned > " + ex.Message);
        }
    }
}

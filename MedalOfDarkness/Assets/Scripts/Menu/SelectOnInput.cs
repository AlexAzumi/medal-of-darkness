using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public EventSystem m_EventSystem;
    public GameObject m_SelectedObject;

    public void Start()
    {
        SelectSelected(m_SelectedObject);
    }

    public void SelectSelected(GameObject SelectedObject)
    {
        m_EventSystem.SetSelectedGameObject(SelectedObject);
    }

    public void RemoveSelection()
    {
        m_EventSystem.SetSelectedGameObject(null);
    }
}

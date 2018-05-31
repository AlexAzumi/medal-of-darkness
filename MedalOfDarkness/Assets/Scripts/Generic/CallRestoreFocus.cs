using System.Collections;
using UnityEngine;

public class CallRestoreFocus : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */
    public FocusObjectGeneric m_Focus;

    public void RestoreFocus()
    {
        m_Focus.RestoreCamera();
    }
}

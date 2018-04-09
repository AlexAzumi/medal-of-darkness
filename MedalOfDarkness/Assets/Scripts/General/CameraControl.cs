using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Private stuff */
    private Camera m_MainCamera;

	void Awake() 
    {
        m_MainCamera = Camera.main;
	}

    public bool SetCameraSize(float size, bool transition, float velocity)
    {
        if (m_MainCamera.orthographicSize.Equals(size))
            return true;
        else
        {
            if (transition)
            {
                float cameraSize = m_MainCamera.orthographicSize;
                //Debug.Log("Orthographic size = " + cameraSize);
                if (cameraSize < size)
                    cameraSize += velocity;
                if (cameraSize > size)
                    cameraSize -= velocity;

                m_MainCamera.orthographicSize = (float)System.Math.Round(cameraSize, 2);
                return false;
            }
            else
            {
                m_MainCamera.orthographicSize = size;
                return true;
            }
        }
    }
}

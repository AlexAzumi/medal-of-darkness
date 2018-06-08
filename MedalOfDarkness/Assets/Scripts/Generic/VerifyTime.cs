using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyTime : MonoBehaviour 
{
    private void Start()
    {
        if (Time.timeScale < 1.0f)
        {
            Time.timeScale = 1.0f;
            Debug.Log("Time scale was restored to 1.0f");
        }
    }
}

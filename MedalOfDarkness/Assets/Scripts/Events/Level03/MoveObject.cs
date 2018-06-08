using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour 
{
    public Vector3 m_Movement;
    public float m_Smoothing;

    private Vector3 newPosition;
    private bool moveObj;

    private void Start()
    {
        newPosition = gameObject.transform.position + m_Movement;
        moveObj = false;
    }

    private void FixedUpdate()
    {
        if (moveObj)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, m_Smoothing * Time.deltaTime);
        }
    }

    public void Move()
    {
        moveObj = true;
    }
}

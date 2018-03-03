using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* PUBLIC VARIABLES */

    //Character movement
    public float m_WalkSpeed = 2.0f; //Walk speed multiplier
    public float m_RunSpeed = 3.5f; //Run speed multiplier
    public bool m_CanRun = true; //Can the player run?
    public bool m_CanMove = true; //Can the player move?
    public Animator m_Animation; //Control animations

    //Camera movement
    public float m_ZoomSpeed = 0.1f; //Camera zoom speed multiplier
    public float m_MaxZoom = 3.5f; //Max camera zoom
    public float m_MinZoom = 4.5f; //Min camera zoom

    /* PRIVATE VARIABLES */
    private Rigidbody m_PlayerRB; //Player's rigidbody
    private Vector3 m_Movement; //Vector to save the direcction of player input
    private Transform m_Camera; //Control of camera's position and size
    private bool m_IsWalking; //Flag to know if player's walking
    private bool m_IsRunning; //Flag to know if player's running
    private float m_ActualZoom; //Value of the orthographic's camera zoom

	void Awake() 
    {
        m_PlayerRB = GetComponent<Rigidbody>(); //Gets rigidbody component (from character)
        m_Animation = GetComponent<Animator>(); //Gets animator component (from character)
        m_IsWalking = false; //Player starts at idle
	}

	void FixedUpdate() //Updates the movement values
    {
        if (m_CanMove)
        {
            float horizontalAxis = Input.GetAxisRaw("Horizontal"); //Horizontal axis
            float verticalAxis = Input.GetAxisRaw("Vertical"); //Vertical axis
            m_Camera = Camera.main.GetComponent<Transform>(); //Gets tranform from the main camera
            m_IsRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton1); //Gets Shitf key or B button on Xbox Controller

            //Call functions
            MoveCharacter(horizontalAxis, verticalAxis);
            Animation(horizontalAxis, verticalAxis);
        }
	}

    void MoveCharacter(float hAxis, float vAxis)
    {
        if (hAxis != 0 || vAxis != 0)
        {
            Vector3 forward = m_Camera.transform.TransformDirection(Vector3.forward);
            forward.y = 0.0f;
            forward = forward.normalized;

            Vector3 right = new Vector3(forward.z, 0.0f, -forward.x);

            m_Movement = (hAxis * right + vAxis * forward);

            if (m_CanRun && m_IsRunning)
            {
                m_Movement = m_Movement.normalized * m_RunSpeed * Time.deltaTime;
            }
            else
            {
                m_Movement = m_Movement.normalized * m_WalkSpeed * Time.deltaTime;
            }

            Quaternion charRotation = Quaternion.LookRotation(m_Movement);

            m_PlayerRB.MoveRotation(charRotation);
            m_PlayerRB.MovePosition(transform.position + m_Movement);
        }
        else
        {
            m_PlayerRB.velocity = Vector3.zero;
            m_PlayerRB.angularVelocity = Vector3.zero;
        }
    }

    void Animation(float hAxis, float vAxis)
    {
        m_IsWalking = hAxis != 0.0f || vAxis != 0.0f;
        bool running = m_IsRunning && m_CanRun;
        m_Animation.SetBool("IsWalking", m_IsWalking);
        m_Animation.SetBool("IsRunning", running);
    }
}

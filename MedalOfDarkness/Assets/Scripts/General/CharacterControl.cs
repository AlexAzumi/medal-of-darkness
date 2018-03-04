using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Public stuff */
    public PlayerController m_Player;

    public void SetCanMove(bool canMove)
    {
        m_Player.m_CanMove = canMove;
    }

    public void SetCanRun(bool canRun)
    {
        m_Player.m_CanRun = canRun;
    }
}

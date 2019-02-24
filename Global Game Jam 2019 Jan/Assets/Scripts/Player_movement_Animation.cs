using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_movement_Animation : MonoBehaviour
{
    //Variables

    public Animator ani;
    public Player refrence;

    public bool canJump;
    public bool isRunning;



    // Sees if the player if jumping, if true will play the jumping animation.
    public void jump_cheak()
    {
        if (canJump == true)
        {
            ani.SetBool("Bool_isJumping", true);
        }
        else if (canJump == false)
        {
            ani.SetBool("Bool_isJumping", false);
        }
    }


    // Sees if the player if running, if true will play the running animation.
    public void run_cheak()
    {
        if (isRunning == true)
        {
            ani.SetBool("Bool_isRunning", true);
        }
        else if (isRunning == false)
        {
            ani.SetBool("Bool_isRunning", false);
        }
    }
}

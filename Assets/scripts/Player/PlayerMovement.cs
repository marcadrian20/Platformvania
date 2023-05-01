using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider slider;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool MoveLeft = false,MoveRight=false;
    bool jump = false;
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (MoveLeft)
            horizontalMove = -runSpeed;
        else if (MoveRight)
            horizontalMove = runSpeed;
        else horizontalMove = 0;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    //touch controls
    public void Jump()
    {
        jump = true;
        animator.SetBool("IsJumping", true);
    }//
    public void Left()
    {
        MoveLeft = true;
    }
    public void LeftClean()
    {
        MoveLeft = false;
    }
    
    public void Right()
    {
        MoveRight = true;
    }
    public void RightClean()
    {
        MoveRight = false;
    }
    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()//we handle moving
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

    }
}

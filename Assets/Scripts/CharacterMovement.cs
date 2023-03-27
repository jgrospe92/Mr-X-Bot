using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 gravity;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;

    private int characterSpeed;

    private float velocity = 0.0f;

    private float deaccelaration = 5f;

    private float walkSpeed = 5;
    private float runSpeed = 8;

    private int maxJump = 2;
    private bool isDoubleJumping = false;

    private bool isMoving = true;

    public ParticleSystem ps;

    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
  
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        characterSpeed = Animator.StringToHash("Character Speed");
   
       
    }

    public void Update()
    {
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            DoubleJump("stop");
            // Jumping
            if (Input.GetButtonDown("Jump"))
            {

                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            }
            else
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }

        if (!isDoubleJumping)
        {
            if (Input.GetButtonDown("Jump") && !groundedPlayer)
            {
                gravity.y += Mathf.Sqrt(0.5f * -3.0f * gravityValue);
                DoubleJump("jump");
                ps.Play();

                isDoubleJumping = true;
            }
        }
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
      

        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        Vector3 direction = move.normalized;

      


        // TODO add animation SetParameters for Idle/Walk/Run
        if (Math.Abs(move.x) > 0.0f || (Math.Abs(move.z) > 0.0f))
        {
            isMoving = true;
            
            if (speed == 5)
            {
                if (velocity > 0.5f) 
                {
                    // to make sure that the animation switched back to walking after running
                    velocity -= Time.deltaTime * speed;
                }
                if (velocity <= 0.5f)
                {
                    // walking animation
                    velocity += Time.deltaTime * speed;
                }
                
            }
            else
            {
                // running annimation
                if (velocity <= 1f)
                {
                    
                    velocity += Time.deltaTime * speed;
                }
                
            }
          
        }
        else
        {
            // idle animation
            isMoving = false;
            if (velocity >= 0.0f)
            {
                velocity -= Time.deltaTime * deaccelaration;
            }
        }

        // make sure to reset velocity to 0.0f
        if (!isMoving && velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        animator.SetFloat(characterSpeed, velocity);

        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }


        // Falling
        Falling();

        // TODO

        // Since there is no physics applied on character controller we have this to reapply gravity
        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //    //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

           

        //}
  
        playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;    
        controller.Move(playerVelocity);

    }

    float GetMovementSpeed()
    {
       
        if (Input.GetButton("Fire3"))// Left shift
        {
          
            return runSpeed;
        }
        else
        {
     
            return walkSpeed;
        }
    }
    
    void DoubleJump(string state)
    {
        if (state.Equals("jump"))
        {
            animator.SetBool("Double Jump", true);
        } else
        {

            animator.SetBool("Double Jump", false);
        }
        
    }

    void Falling()
    {
        if (!groundedPlayer)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Make sure to add a "character controller" to player assets as well as some form of a collider
//Player assest also needs a transform where it meets the ground to function

public class movement : MonoBehaviour
{
    public CharacterController control; //the character controller on the player assest 

    [SerializeField] float movSpeed;
    [SerializeField] float grav; //gravity
    [SerializeField] float jumpHeight;

    public Transform groundCheck;// make sure player is on the ground
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
   
    Vector3 velocity;
    Vector3 move;
    Vector3 dash;

    bool isGrounded;
    bool jumpPressed;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //walking
        move = transform.right * x + transform.forward * z;
        
        control.Move(move * movSpeed);

        //dash and/or short range teleport
        if(Input.GetKeyDown(KeyCode.Shift))
        {
            dash = transform.right * x * 10 + transform.forward * z * 10;

            control.Move(dash * movSpeed * 10);
         }

        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
        }

       
    }

    private void FixedUpdate()
    {
        //jump cont.
        if(jumpPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
            jumpPressed = false;
        }

        //falling
        velocity.y += grav * Time.deltaTime;

        control.Move(velocity * Time.deltaTime * 1.5f);
    }
}

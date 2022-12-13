using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //movement variables
    public CharacterController controller;
    public float speed = 12f;

    //gravity + ground check variables
    public float gravity = -9.81f;
    
    public Transform groundCheck; //don't forget to assign the groundcheck object to this variable
    public float groundDistance = 2f;
    public LayerMask groundMask;

    
    Vector3 velocity;
    bool isGrounded;

    //jumping var
    public float jumpHeight = 3f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 

        controller.Move(move * speed * Time.deltaTime);


        //gravity
        velocity.y += gravity * Time.deltaTime;//
        controller.Move(velocity * Time.deltaTime);//


        //jummping mechenics
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

}
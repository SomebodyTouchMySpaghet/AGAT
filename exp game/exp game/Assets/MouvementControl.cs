using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementControl : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isSprinting = false;
    public float sprintingMultiplier;
    
    Vector3 velocity;
    bool isGrounded;

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

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)

        {
            velocity.y =Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;     
        }

        if (isSprinting == true)
        {
            speed *= sprintingMultiplier;
        }

        if (speed > 36f)
        {
            speed = 36f;
        }

        if (isSprinting == false)

        if (speed > 12f)
        {
            speed = 12f;
        }
    }   
}
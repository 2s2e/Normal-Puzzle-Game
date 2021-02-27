using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Range(0f, 35f)]
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    Vector3 velocity; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public LayerMask infiniteMask;
    bool isInf;
    void Update()
    {
        //Moves the player, shift to move faster
        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = 20f;
        } else {
            speed = 12f;
        }
        //If in infinite Hallway, then running slows down you instead
        isInf = Physics.CheckSphere(groundCheck.position, groundDistance, infiniteMask);
        if(isInf) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                speed = 5f;
                Debug.Log("slowing");
            }
            Debug.Log("touching");
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * speed * Time.deltaTime);
      
        //Implements Jumping
        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Bruh");
            transform.Translate(5, 5, 5);
        }

        //Implements gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}

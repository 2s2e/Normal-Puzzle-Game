using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Range(0f, 35f)]
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    Vector3 velocity; 

    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Transform groundCheck;
    public bool isRunning;

    //Sound
    private float nextFootstep = 0;
    public float footStepDelay;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
            isRunning = true;
        } else {
            speed = 8f;
            isRunning = false;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; 

        //If Walking, play walking audio
        if(move.magnitude > 0) {
            Debug.Log("Is Walking"); 
            nextFootstep -= Time.deltaTime;
            if(nextFootstep <= 0) {
                FindObjectOfType<AudioManager>().Play("PlayerWalk");
                nextFootstep += footStepDelay;
            }
        } else {
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
        }
        controller.Move(move * speed * Time.deltaTime);
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Implements Jumping
        if(Input.GetButtonDown("Jump")) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.enabled = false;
            transform.position = new Vector3(27,5,-19);
            controller.enabled = true;
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

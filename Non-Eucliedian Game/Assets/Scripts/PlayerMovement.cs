using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Range(0f, 35f)]
    public float speed = 7.5f;
    public float gravity = -18f;
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
        AudioManager manager = FindObjectOfType<AudioManager>();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
            isRunning = true;

        } else {
            speed = 7.5f;
            isRunning = false;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; 

        //If Walking, play walking audio 
        if(move.magnitude > 0 && isGrounded) {
            Debug.Log("Is Walking"); 
            nextFootstep -= Time.deltaTime;
            if(nextFootstep <= 0) {
                if(isRunning)
                    manager.Play("PlayerRun");
                else
                    manager.Play("PlayerWalk");
                nextFootstep += footStepDelay;
            }
        } else {
            if(isRunning)
               manager.Stop("PlayerRun");
            else
               manager.Stop("PlayerWalk");
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

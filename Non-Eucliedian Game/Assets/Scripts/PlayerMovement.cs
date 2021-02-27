﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Range(0f, 35f)]
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity; 
    void Update()
    {
        //Moves the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * speed * Time.deltaTime);

        //Implements gravity
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime);
        
    }
}

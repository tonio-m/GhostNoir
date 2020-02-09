using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float gravity = 9.8f;

    public CharacterController characterController;
    
    Vector3 movement;
    Vector3 gravMovement;

    void Update()
    { 
        move();
        applyGravity();
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        movement = transform.right * x + transform.forward * z;
        characterController.Move(movement * speed * Time.deltaTime);
    }

    void applyGravity()
    {
        gravMovement += Vector3.down * gravity * (Time.deltaTime * Time.deltaTime);
        characterController.Move(gravMovement);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    // rigidbody for motion and collisions
    public Rigidbody2D body;

    // vector of current movement direction + speed
    Vector2 movement;

    // for linking player motion to animations in animation editor
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        // Get input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Set animation vars
        // make sure we don't set them if the player is standing still, to prevent weird flipping
        if (movement.x != 0)
        {
            anim.SetFloat("Horizontal", movement.x);
        }

        if (movement.y != 0)
        {
            anim.SetFloat("Vertical", movement.y);
        }

        anim.SetFloat("Speed", movement.sqrMagnitude); //some sort of wild magic variable that pulls the squared length of the vector
    }

    void FixedUpdate()
    {

        body.MovePosition(body.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }

}

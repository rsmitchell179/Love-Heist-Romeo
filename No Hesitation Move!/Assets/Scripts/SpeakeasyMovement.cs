using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakeasyMovement : MonoBehaviour
{

	public Animator anim;
	public Vector2 movement;
	public Rigidbody2D body;
	public float moveSpeed;
	public bool is_climbing = false;
	public GameObject ladder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	romeo_walk();
    }

    void romeo_walk()
    {
    	movement.x = Input.GetAxis("Horizontal");
    	movement.y = Input.GetAxis("Vertical");

    	if(movement.x != 0.0f && is_climbing == false)
    	{
    		anim.SetFloat("Horizontal", movement.x);
    	}

    	if(movement.y != 0.0f && is_climbing == true)
    	{
    		anim.SetFloat("Vertical", movement.y);
    	}

    	anim.SetFloat("Speed", movement.sqrMagnitude);

    	if(is_climbing == false)
    	{
    		body.velocity = new Vector2(movement.x * moveSpeed, body.velocity.y);
    	}
    	else
    	{
    		body.MovePosition(body.position + (movement * moveSpeed * Time.fixedDeltaTime));
    	}
    }
}

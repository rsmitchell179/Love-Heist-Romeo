using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

	public SpeakeasyMovement se_mvmt;
	public Rigidbody2D r_rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	// Debug.Log("collision detected");
    	if(other.gameObject.tag == "Player")
    	{
    		// se_mvmt.is_climbing = true;
    		r_rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
    		// Debug.Log(se_mvmt.is_climbing);
    	}
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		se_mvmt.is_climbing = true;
    		r_rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
    		// Debug.Log(se_mvmt.is_climbing);
    	}
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if(other.gameObject.tag == "Player")
    	{
    		se_mvmt.is_climbing = false;
    		r_rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    		// Debug.Log(se_mvmt.is_climbing);
    	}

    }
}

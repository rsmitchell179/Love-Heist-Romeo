using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakeasyManager : MonoBehaviour
{

    public playerMovement p_move;
    public Rigidbody2D r_rb;

    // Start is called before the first frame update
    void Start()
    {
        p_move = FindObjectOfType<playerMovement>();
        r_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
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
            // p_move.move_vertical = true;
            r_rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            // Debug.Log(p_move.move_vertical);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            p_move.move_vertical = true;
            r_rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            // Debug.Log(p_move.move_vertical);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            p_move.move_vertical = false;
            r_rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            // Debug.Log(p_move.move_vertical);
        }

    }
}

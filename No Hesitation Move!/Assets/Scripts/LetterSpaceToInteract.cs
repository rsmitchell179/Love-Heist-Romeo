using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSpaceToInteract : MonoBehaviour {

	public int bool_index;
	public bool bubble_bool = false;
	public bool is_colliding = false;

	public Image bubble;
	public Image space_bar;

	public Animator anim;

	public GameObject character;

	public Camera cam;
	// public AnimationClip space_press;

    // Start is called before the first frame update
    void Start()
    {
        bubble.enabled = false;
        space_bar.enabled = false;
        // anim.enabled = false;
        // Debug.Log("is_colliding is " + is_colliding);
    }

    // Update is called once per frame
    void Update()
    {

    	if(Input.GetKeyDown(KeyCode.Space) && is_colliding == true)
    	{
    		bubble_bool = true;
    	}

        if(bubble_bool == true){
        	bubble.enabled = false;
        	space_bar.enabled = false;
        	// anim.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		play_space();
    		
    	}
    }

    public void play_space()
    {
    	// Debug.Log("play_space");
    	bubble.enabled = true;
    	space_bar.enabled = true;
    	set_pos(bubble);
    	set_pos(space_bar);
    	// anim.enabled = true;
    	// yield return new WaitForSecondsRealtime(0.2f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
			set_pos(bubble);
	    	set_pos(space_bar);
	    	// Debug.Log("is_colliding is " + is_colliding);
	    	is_colliding = true;
	    	// Debug.Log("is_colliding is " + is_colliding);
    	}
    	
    }

    void OnTriggerExit2D(Collider2D other)
    {

    	if(other.gameObject.tag == "Player")
    	{
    		bubble.enabled = false;
    		space_bar.enabled = false;
    		is_colliding = false;
            bubble_bool = false;
    	}
    	
    	// anim.enabled = false;
    }

    void set_pos(Image bub)
    {
    	float y_offset = character.GetComponent<SpriteRenderer>().bounds.max.y + 0.6f;
    	Vector3 bub_position = new Vector3(character.transform.position.x, y_offset, character.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }
}


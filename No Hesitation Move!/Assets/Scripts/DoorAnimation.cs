using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

	public SpriteRenderer door;
	public Sprite door_opened;
	public Sprite door_closed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		door.sprite = door_opened;
    	}
    }

    void OnTriggerExit2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		door.sprite = door_closed;
    	}
    }
}

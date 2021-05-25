using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCExit : MonoBehaviour
{

	public SpriteRenderer door;
	public Sprite door_opened;
	public Sprite door_closed;
    public BoxCollider2D door_collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.hasRCorb == true)
        {
            door_collider.enabled = true;
        }
        else
        {
            door_collider.enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player" && GlobalVars.hasRCorb == true)
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

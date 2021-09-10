using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTExit : MonoBehaviour
{

    public SpriteRenderer door;
    public Sprite door_opened;
    public Sprite door_closed;
    public BoxCollider2D door_collider;

    // Start is called before the first frame update
    void Update()
    {
        if(GlobalVars.ft_orb_get == true)
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
        if(other.gameObject.tag == "Player" && GlobalVars.ft_orb_get == true)
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

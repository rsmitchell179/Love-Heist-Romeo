using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSBoatBackPathScript : MonoBehaviour
{
    public GameObject ladder_trigger;
    public Collider2D boat_wheel;
    public BoxCollider2D db_collider;
    public DoughboyDialogue db_dialogue;
    public GameObject db_bubble;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ladder_trigger.SetActive(false);
            boat_wheel.enabled = false;
            db_collider.enabled = false;
            db_dialogue.enabled = false;
            db_bubble.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ladder_trigger.SetActive(true);
            boat_wheel.enabled = true;
            db_collider.enabled = true;
            db_dialogue.enabled = true;
            db_bubble.SetActive(true);
        }
    }
}

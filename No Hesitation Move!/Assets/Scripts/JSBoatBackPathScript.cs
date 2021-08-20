using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSBoatBackPathScript : MonoBehaviour
{

    public bool is_active;
    public GameObject poker_roof;
    public Collider2D boat_wheel;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            poker_roof.SetActive(false);
            boat_wheel.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            poker_roof.SetActive(true);
            boat_wheel.enabled = true;
        }
    }
}

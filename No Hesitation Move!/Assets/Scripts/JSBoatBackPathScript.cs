using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSBoatBackPathScript : MonoBehaviour
{

    public bool is_active;
    public GameObject poker_roof;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            poker_roof.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            poker_roof.SetActive(true);
        }
    }
}

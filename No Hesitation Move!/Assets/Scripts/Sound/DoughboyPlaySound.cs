using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughboyPlaySound : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
            Debug.Log("Playing");
            source.Play();
    	}
    }

}

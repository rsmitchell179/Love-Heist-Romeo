using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsOrb : MonoBehaviour
{
    AudioSource orb_source;

    void Awake()
    {
        orb_source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SoundVars.JSorbplayed == 1)
        {
            orb_source.volume = 0;
        }
        else
        {
            orb_source.volume = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
            SoundVars.JSorb = 1;
    	}
    }

}

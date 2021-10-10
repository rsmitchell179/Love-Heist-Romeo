using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcOrb : MonoBehaviour
{
    AudioSource orb_source;

    void Awake()
    {
        orb_source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SoundVars.RCorbplayed == 1)
        {
            orb_source.Stop();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
            SoundVars.RCorb = 1;
    	}
    }

}

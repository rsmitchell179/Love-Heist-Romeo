using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtOrb : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
            SoundVars.FTorb = 1;
    	}
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
            SoundVars.JSorb = 1;
    	}
    }

}

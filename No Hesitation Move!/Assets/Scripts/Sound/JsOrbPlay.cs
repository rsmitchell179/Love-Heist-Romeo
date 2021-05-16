using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsOrbPlay : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if((SoundVars.JSorb == 1) && (SoundVars.JSorbplayed == 0)){
          source.Play();
          SoundVars.JSorbplayed = 1;
        } 
    }
}

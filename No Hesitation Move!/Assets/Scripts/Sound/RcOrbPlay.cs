using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcOrbPlay : MonoBehaviour
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
        if((SoundVars.RCorb == 1) && (SoundVars.RCorbplayed == 0)){
          source.Play();
          SoundVars.RCorbplayed = 1;
        } 
    }
}

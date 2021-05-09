using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcPlayStart : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>(); 
        source.time = 1;
        source.Play();
        SoundVars.RCTime = 0; 
        SoundVars.STOPRCINIT = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if((source.time < 1) && (SoundVars.STOPRCINIT == 0)){
          source.Stop();
          SoundVars.RCStart = 1;
          SoundVars.STOPRCINIT = 5;
        } 
    }
}

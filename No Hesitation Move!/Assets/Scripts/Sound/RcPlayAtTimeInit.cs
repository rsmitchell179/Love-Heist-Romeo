using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcPlayAtTimeInit : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>(); 
        source.time = SoundVars.RCTime;
         
    }

    // Update is called once per frame
    void Update()
    {
        if(SoundVars.RCStart == 1){
          source.Play();
          SoundVars.RCStart = 0;
          source.time = SoundVars.RCTime;
        }
        SoundVars.RCTime = source.time;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneIntro: MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>(); 
        source.time = 1;
        source.Play();
        SoundVars.CSIntro = 0; 
        SoundVars.STOPCSINTRO = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if((source.time < 1) && (SoundVars.STOPCSINTRO == 0)){
          source.Stop();
          SoundVars.CSIntro = 1;
          SoundVars.STOPCSINTRO = 5;
        } 
    }
}

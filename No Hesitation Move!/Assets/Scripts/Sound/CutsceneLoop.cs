using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLoop: MonoBehaviour
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
        if(SoundVars.CSIntro == 1){
          source.Play();
          SoundVars.CSIntro = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtOrbPlay : MonoBehaviour
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
        if((SoundVars.FTorb == 1) && (SoundVars.FTorbplayed == 0)){
          source.Play();
          SoundVars.FTorbplayed = 1;
        } 
    }
}

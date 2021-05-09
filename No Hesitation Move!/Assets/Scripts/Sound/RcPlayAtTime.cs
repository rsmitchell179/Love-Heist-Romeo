using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcPlayAtTime : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>(); 
        source.time = SoundVars.RCTime;
        source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundVars.RCTime = source.time;
    }
}

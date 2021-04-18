using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtPlayAtTime : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); 
        source.time = SoundVars.FTTime;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SoundVars.FTTime = source.time;
    }
}

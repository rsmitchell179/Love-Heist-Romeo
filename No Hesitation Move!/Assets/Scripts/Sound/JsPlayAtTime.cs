using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsPlayAtTime : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); 
        source.time = SoundVars.JSTime;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SoundVars.JSTime = source.time;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCJukeboxPlay : MonoBehaviour
{

    public AudioSource[] jukebox_tracks;
    public int current_track;
    public RCJukebox rc_jukebox;

    // Start is called before the first frame update
    void Start()
    {
        current_track = rc_jukebox.current_step;

        for(int i = current_track; i < rc_jukebox.current_step; i++)
        {
            jukebox_tracks[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rc_jukebox.current_step != current_track)
        {
            jukebox_tracks[current_track].Stop();
            jukebox_tracks[rc_jukebox.current_step].Play();
            current_track = rc_jukebox.current_step;
        }

        if(rc_jukebox.jukebox_bool == true && rc_jukebox.start_playing_bool == false)
        {
            jukebox_tracks[current_track].Play();
        }
    }
}

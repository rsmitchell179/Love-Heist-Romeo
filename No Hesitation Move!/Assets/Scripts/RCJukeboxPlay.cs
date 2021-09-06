using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCJukeboxPlay : MonoBehaviour
{

    public AudioSource[] jukebox_tracks;
    public AudioSource[] transition_sfx;
    public int current_track;
    public int random_sfx;
    public RCJukebox rc_jukebox;
    public bool check_transition;
    public bool check_random;

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

        if(rc_jukebox.currently_lerping == true)
        {
            check_transition = true;
        }
        else
        {
            check_transition = false;
        }

        if(check_transition == true)
        {
            jukebox_tracks[current_track].Stop();

            if(check_random == false)
            {
                set_random();
            }
        }
        else
        {
            transition_sfx[random_sfx].Stop();
            check_random = false;
        }
    }

    void set_random()
    {
        random_sfx = Random.Range(0, 9);
        transition_sfx[random_sfx].Play();
        check_random = true;
    }
}

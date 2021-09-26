using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSWaves : MonoBehaviour
{

    public AudioSource wave_sound;
    public AudioClip wave_sfx;
    public bool is_playing;
    public bool past_startup;
    public float time;
    public float low_vol;
    public float hi_vol;
    public float first_duration;
    public float second_duration;
    public float wave_pitch;
    public float wait_time;
    public float startup_time;

    void Awake()
    {
        wave_sound = this.gameObject.GetComponent<AudioSource>();
        wave_sfx = wave_sound.clip;
        wave_pitch = Random.Range(1, 4);
        first_duration = ((wave_sfx.length / wave_pitch)/4)*3;
        second_duration = ((wave_sfx.length / wave_pitch)/4);
        startup_time = Random.Range(1.0f, 5.0f);
        past_startup = true;
    }

    void Start()
    {
        StartCoroutine(delay_wave(startup_time));
    }

    // Update is called once per frame
    void Update()
    {
        if(wave_pitch == 2 || wave_pitch == 3)
        {
            hi_vol = 0.6f;
        }
        else
        {
            hi_vol = 0.5f;
        }

        if(!is_playing && !past_startup)
        {
            wave_sound.volume = 0.0f;
            StartCoroutine(play_wave(low_vol, hi_vol));
        }
    }

    IEnumerator play_wave(float low_vol_val, float high_vol_val)
    {
        is_playing = true;
        wave_sound.pitch = wave_pitch;
        wave_sound.Play();
        time = 0f;
        while(time < first_duration)
        {
            wave_sound.volume = Mathf.Lerp(low_vol_val, high_vol_val, time / first_duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.0f);

        time = 0f;
        while(time < second_duration)
        {
            wave_sound.volume = Mathf.Lerp(high_vol_val, low_vol_val, time / second_duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.0f);

        wave_sound.Stop();

        yield return new WaitForSecondsRealtime(wait_time);
        is_playing = false;
        wave_pitch = Random.Range(1, 4);
    }

    IEnumerator delay_wave(float startup_duration)
    {
        float local_time = 0f;
        while(local_time < startup_duration)
        {
            local_time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);

        past_startup = false;
    }
}

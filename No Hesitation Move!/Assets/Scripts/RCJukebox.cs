using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RCJukebox : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject jukebox_menu;
    public GameObject pause_stuff;
    public GameObject pause_menu;

    [Header("Player Components")]
    public playerMovement p_move;

    [Header("Jukebox Checks")]
    public bool standing_on_jukebox;
    public bool jukebox_bool;
    public bool let_move_left;
    public bool let_move_right;

    [Header("Jukebox Components")]
    public Image pointer;
    public Image jukebox_knob;
    public int[] jukebox_steps;
    public int current_step;
    public float pointer_x;
    public float pointer_y;
    public float end_of_lerp_pointer;
    public float step_length;
    public float knob_rotation;
    public float duration;
    public bool allow_movement;
    public bool currently_lerping;
    public AudioSource scene_music;
    public bool has_opened_jukebox;
    public bool start_playing_bool;
    public bool check_pause_menu;

    void Awake()
    {
        jukebox_bool = false;
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
        jukebox_steps = new int[12];
        for(int i = 0; i < jukebox_steps.Length; i++)
        {
            jukebox_steps[i] = i;
        }
        current_step = jukebox_steps[0];

        start_playing_bool = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(standing_on_jukebox && !check_pause_menu)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(jukebox_bool)
                {
                    jukebox_bool = false;
                }
                else
                {
                    jukebox_bool = true;
                    scene_music.Stop();
                }
            }
        }

        if(jukebox_bool == true)
        {
            p_move.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            p_move.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            jukebox_menu.SetActive(true);
            pause_stuff.SetActive(false);
            p_move.enabled = false;
            check_movement();
            move_pointer();
        }
        else
        {
            jukebox_menu.SetActive(false);
            pause_stuff.SetActive(true);
            p_move.enabled = true;
        }

        if(currently_lerping)
        {
            allow_movement = false;
        }
        else
        {
            allow_movement = true;
        }

        if(has_opened_jukebox == false && jukebox_bool == true)
        {
            StartCoroutine(start_playing());
        }

        if(pause_menu.activeInHierarchy == true)
        {
            check_pause_menu = true;
        }
        else
        {
            check_pause_menu = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            standing_on_jukebox = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            standing_on_jukebox = false;
        }
    }

    void check_movement()
    {
        if(allow_movement)
        {
            if(current_step == jukebox_steps[0])
            {
                let_move_left = false;
                let_move_right = true;
            }
            else if(current_step == jukebox_steps[11])
            {
                let_move_left = true;
                let_move_right = false;
            }
            else
            {
                let_move_left = true;
                let_move_right = true;
            }
        }
        else
        {
            let_move_left = false;
            let_move_right = false;
        }
    }

    void move_pointer()
    {
        if(let_move_left)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                // current_step--;
                pointer_x = pointer.GetComponent<RectTransform>().anchoredPosition.x;
                Vector2 pointer_pos = pointer.GetComponent<RectTransform>().anchoredPosition;
                StartCoroutine(lerp_pointer(-step_length, pointer_pos, knob_rotation, false));
            }
        }

        if(let_move_right)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                // current_step++;
                pointer_x = pointer.GetComponent<RectTransform>().anchoredPosition.x;
                Vector2 pointer_pos = pointer.GetComponent<RectTransform>().anchoredPosition;
                StartCoroutine(lerp_pointer(step_length, pointer_pos, -knob_rotation, true));
            }
        }
    }

    IEnumerator lerp_pointer(float end_position_x, Vector2 pointer_pos, float knob_rotation, bool change_step)
    {

        currently_lerping = true;

        float end_x = pointer_x + end_position_x;
        float time = 0f;
        Vector2 end_position = new Vector2(end_x, pointer_pos.y);

        while(time < duration)
        {
            jukebox_knob.GetComponent<RectTransform>().Rotate(0.0f, 0.0f, knob_rotation, Space.Self);
            pointer.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(pointer_pos, end_position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(end_of_lerp_pointer);

        if(change_step)
        {
            current_step++;
        }
        else
        {
            current_step--;
        }

        currently_lerping = false;
    }

    IEnumerator start_playing()
    {
        has_opened_jukebox = true;

        yield return new WaitForSecondsRealtime(0.0f);

        start_playing_bool = false;

        yield return new WaitForSecondsRealtime(0.0f);

        start_playing_bool = true;
    }
}

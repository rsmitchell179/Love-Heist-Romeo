using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldLetters : MonoBehaviour
{

    [Header("Letter Sprite")]
    public SpriteRenderer letter_renderer;
    public Sprite letter_opened;
    public Sprite letter_closed;

    [Header("Letter Components")]
    public int chap_arr_index;
    public Image ui_letter;
    public bool letter_open;
    public bool animation_bool;
    public Animator anim;

    [Header("Other Components")]
    public playerMovement p_move;
    public bool is_standing;
    public bool stop_player_movement;

    void Awake()
    {

        letter_renderer = this.GetComponent<SpriteRenderer>();
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
        ui_letter.enabled = false;

        if(GlobalVars.chap_array[chap_arr_index] == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        // if(GlobalVars.chap_array[chap_arr_index] == false)
        // {
        //     this.gameObject.SetActive(false);
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        letter_renderer.sprite = letter_closed;
    }

    // Update is called once per frame
    void Update()
    {
        if(letter_open == true)
        {
            letter_close();
        }

        if(stop_player_movement == true)
        {
            p_move.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            p_move.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            p_move.enabled = false;
        }
        else
        {
            p_move.enabled = true;
        }

        if(is_standing == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) && animation_bool == false)
            {
                if(GlobalVars.chap_array[chap_arr_index] == false)
                {
                    GlobalVars.chap_array[chap_arr_index] = true;
                }

                animation_bool = true;
                image_pop_up();

            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 1; i < GlobalVars.chap_array.Length; i++)
            {
                Debug.Log("here");
                GlobalVars.chap_array[i] = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            is_standing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            is_standing = false;
        }
    }

    public void image_pop_up()
    {
        ui_letter.enabled = true;
        StartCoroutine(start_letter_zoom());
    }

    IEnumerator start_letter_zoom()
    {
        stop_player_movement = true;

        yield return new WaitForSecondsRealtime(1.0f);

        anim.Play("letter_zoom", 0, 0f);

        yield return new WaitForSecondsRealtime(2.0f);

        set_letter_true();
    }

    public void set_letter_true()
    {
        letter_open = true;
    }

    public void letter_close()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            ui_letter.enabled = false;
            letter_open = false;
            p_move.enabled = true;
            letter_renderer.sprite = letter_opened;
            StartCoroutine(set_anim_bool_off());
            anim.Rebind();
            anim.Update(0f);
        }
    }

    IEnumerator set_anim_bool_off()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        animation_bool = false;
        stop_player_movement = false;
    }
}

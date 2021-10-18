using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLetters : MonoBehaviour {
	
    [SerializeField]
    private bool stop_player_movement;

    [Header("Letter Sprite")]
    public SpriteRenderer letterRender;
	public Sprite letter_opened;
	public Sprite letter_closed;

	[Header("Letter Components")]
    public int chap_arr_index;
	public Image letter;
	public bool letter_open = false;
    public playerMovement p_move;
    [SerializeField]
    private bool is_standing;
    

	[Header("Animation Components")]
    public bool animation_bool = false;
    public Animator anim;
    public AnimationClip letter_zoom;

    

    // Start is called before the first frame update
    void Start() {
        letter.enabled = false;
        is_standing = false;
    }

    // Update is called once per frame
    void Update() {
        
        if(letter_open == true){
            p_move.enabled = false;
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

        // if(GlobalVars.chapISeen == true && gameObject.tag == "Chapter I") {
        //     letterRender.sprite = letter_opened;
        // }
        // if(GlobalVars.chapIVSeen == true && gameObject.tag == "Chapter IV") {
        //     letterRender.sprite = letter_opened;
        // }
        // if(GlobalVars.chapIXSeen == true && gameObject.tag == "Chapter IX") {
        //     letterRender.sprite = letter_opened;
        // }
        // if(GlobalVars.chapIISeen == true && gameObject.tag == "Chapter II") {
        //     letterRender.sprite = letter_opened;
        // }
        // if(GlobalVars.chapVIIISeen == true && gameObject.tag == "Chapter VIII") {
        //     letterRender.sprite = letter_opened;
        // }
        // if(GlobalVars.chapVSeen == true && gameObject.tag == "Chapter V") {
        //     letterRender.sprite = letter_opened;
        // }

        if(is_standing == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) && animation_bool == false)
            {
                set_anim_bool();
                if(GlobalVars.chap_array[chap_arr_index] == false)
                {
                    GlobalVars.chap_array[chap_arr_index] = true;
                }

                animation_bool = true;
                image_pop_up();

            }
        }

        if(GlobalVars.chap_array[chap_arr_index] == true)
        {
            letterRender.sprite = letter_opened;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
    	if(other.tag == "Player"){
    		// if (Input.GetKeyDown(KeyCode.Space) && animation_bool == false) {
      //   		if(gameObject.tag == "Chapter I") {
      //           GlobalVars.chapISeen = true;
      //           }
      //           if(gameObject.tag == "Chapter IV") {
      //               GlobalVars.chapIVSeen = true;
      //           }
      //           if(gameObject.tag == "Chapter IX") {
      //               GlobalVars.chapIXSeen = true;
      //           }
      //           if(gameObject.tag == "Chapter II") {
      //               GlobalVars.chapIISeen = true;
      //           }
      //           if(gameObject.tag == "Chapter VIII") {
      //               GlobalVars.chapVIIISeen = true;
      //           }
      //           if(gameObject.tag == "Chapter V") {
      //               GlobalVars.chapVSeen = true;
      //           }
      //           letterRender.sprite = letter_opened;
      //   		animation_bool = true;
      //   		image_pop_up();

      //   	}

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
    	letter.enabled = true;
    	StartCoroutine(start_letter_zoom());	
    }

    public IEnumerator start_letter_zoom()
    {
        stop_player_movement = true;
    	p_move.enabled = false;

    	yield return new WaitForSecondsRealtime(1.0f);

    	anim.Play("letter_zoom", 0, 0f);

        yield return new WaitForSecondsRealtime(2.0f);
        set_letter_true();
    }

    public void set_anim_bool()
    {
    	animation_bool = true;
    }

    public void set_letter_true()
    {
    	letter_open = true;
    }

    public void letter_close()
    {
    	if(Input.GetKeyDown(KeyCode.Space)){
    		letter.enabled = false;
       		letter_open = false;
            p_move.enabled = true;
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

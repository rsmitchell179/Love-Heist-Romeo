using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLetters : MonoBehaviour {
	public SpriteRenderer letterRender;
	public Sprite letter_opened;
	public Sprite letter_closed;

	[Header("letter settings")]
	public Image letter;
	public bool letter_open = false;
    public playerMovement p_move;

	[Header("animation settings")]
    public bool animation_bool = false;
    public Animator anim;
    public AnimationClip letter_zoom;

    Vector3 set_position;
    bool stop_player_movement;
    // Start is called before the first frame update
    void Start() {
        letter.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
        if(letter_open == true){
            p_move.enabled = false;
            letter_close();
        }

        if(stop_player_movement == true)
        {
            p_move.gameObject.transform.position = set_position;
        }
        if(GlobalVars.chapISeen == true && gameObject.tag == "Chapter I") {
            letterRender.sprite = letter_opened;
        }
        if(GlobalVars.chapIVSeen == true && gameObject.tag == "Chapter IV") {
            letterRender.sprite = letter_opened;
        }
        if(GlobalVars.chapIXSeen == true && gameObject.tag == "Chapter IX") {
            letterRender.sprite = letter_opened;
        }
        if(GlobalVars.chapIISeen == true && gameObject.tag == "Chapter II") {
            letterRender.sprite = letter_opened;
        }
        if(GlobalVars.chapVIIISeen == true && gameObject.tag == "Chapter VIII") {
            letterRender.sprite = letter_opened;
        }
        if(GlobalVars.chapVSeen == true && gameObject.tag == "Chapter V") {
            letterRender.sprite = letter_opened;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
    	if(other.gameObject.tag == "Player") {
    		if (Input.GetKeyDown(KeyCode.Space) && animation_bool == false) {
        		if(gameObject.tag == "Chapter I") {
                GlobalVars.chapISeen = true;
                }
                if(gameObject.tag == "Chapter IV") {
                    GlobalVars.chapIVSeen = true;
                }
                if(gameObject.tag == "Chapter IX") {
                    GlobalVars.chapIXSeen = true;
                }
                if(gameObject.tag == "Chapter II") {
                    GlobalVars.chapIISeen = true;
                }
                if(gameObject.tag == "Chapter VIII") {
                    GlobalVars.chapVIIISeen = true;
                }
                if(gameObject.tag == "Chapter V") {
                    GlobalVars.chapVSeen = true;
                }
                letterRender.sprite = letter_opened;
        		animation_bool = true;
        		image_pop_up();

        	}
    	}
    }

    public void image_pop_up()
    {
    	letter.enabled = true;
    	StartCoroutine(start_letter_zoom());
    	StartCoroutine(letter_wait());	
    }

    public IEnumerator letter_wait()
    {
    	yield return new WaitForSecondsRealtime(3);
    	set_letter_true();
    }

    public IEnumerator start_letter_zoom()
    {
        set_position = p_move.gameObject.transform.position;
        stop_player_movement = true;
    	p_move.enabled = false;
    	yield return new WaitForSecondsRealtime(1);
    	anim.Play("letter_zoom", 0, 0f);
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
            stop_player_movement = false;
       	 	animation_bool = false;
       	 	anim.Rebind();
       	 	anim.Update(0f);
    	}
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class LetterPopUp : MonoBehaviour
{	

	DialogueRunner diaRun = null;

	[Header("letter settings")]
	public Image letter;
	public bool letter_open = false;
    public playerMovement p_move;
    public Rigidbody2D r_rb;

    [Header("animation settings")]
    public bool animation_bool = false;
    public Animator anim;
    public AnimationClip letter_zoom;

    [Header("canvas")]
    public GameObject db_canvas;
    public GameObject tutorial_canvas;

    Vector3 set_position;
    bool stop_player_movement;

	void Awake()
	{

        r_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        try{
            diaRun = FindObjectOfType<DialogueRunner>();
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in SpaceContinue, don't worry about it for now");
            }

        try{
            diaRun.AddCommandHandler("image_pop_up", image_pop_up);
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in DialogueSpeaker, don't worry about it for now");
            }
	}

    // Start is called before the first frame update
    void Start()
    {
        letter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // charles bless up
    	if(letter_open == true){
            p_move.enabled = false;
            // r_rb.constraints = RigidbodyConstraints2D.FreezePosition;
            letter_close();
        }

        // if(stop_player_movement == true)
        // {
        //     // p_move.gameObject.transform.position = set_position;
        //     r_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // }

        // if(tutorial_canvas.activeSelf == true)
        // {
        //     letter.enabled = false;
        //     letter_open = false;
        //     p_move.enabled = true;
        //     // stop_player_movement = false;
        //     animation_bool = false;
        //     anim.Rebind();
        //     anim.Update(0f);
        //     db_canvas.SetActive(true);
        // }
    }

    public void image_pop_up(string[] parameters)
    {
    	letter.enabled = bool.Parse(parameters[0]);
    	StartCoroutine(start_letter_zoom());	
    }

    public IEnumerator start_letter_zoom()
    {
        // set_position = p_move.gameObject.transform.position;
        // stop_player_movement = true;
        
        r_rb.constraints = RigidbodyConstraints2D.FreezeAll;
    	p_move.enabled = false;
    	db_canvas.SetActive(false);

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
            r_rb.constraints = RigidbodyConstraints2D.None;
            r_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            // stop_player_movement = false;
       	 	animation_bool = false;
       	 	anim.Rebind();
       	 	anim.Update(0f);
       	 	db_canvas.SetActive(true);
    	}
    }
}

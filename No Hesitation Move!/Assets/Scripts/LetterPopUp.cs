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

    [Header("animation settings")]
    public bool animation_bool = false;
    public Animator anim;
    public AnimationClip letter_zoom;

    [Header("doughboy dialogue canvas")]
    public GameObject db_canvas;

    Vector3 set_position;
    bool stop_player_movement;

	void Awake()
	{
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
            letter_close();
        }

        if(stop_player_movement == true)
        {
            p_move.gameObject.transform.position = set_position;
        }
    }

    public void image_pop_up(string[] parameters)
    {
    	letter.enabled = bool.Parse(parameters[0]);
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
    	db_canvas.SetActive(false);
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
       	 	db_canvas.SetActive(true);
    	}
    }
}

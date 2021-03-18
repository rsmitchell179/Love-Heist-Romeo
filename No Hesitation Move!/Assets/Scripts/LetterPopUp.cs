using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class LetterPopUp : MonoBehaviour
{	

	DialogueRunner diaRun = null;

	// public GameObject player;

	public Image letter;

	public bool letter_open = false;

    public playerMovement p_move;

	void Awake()
	{

		// player = GameObject.FindWithTag("Player");

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
            if(Input.GetKeyDown(KeyCode.Space)){
                letter.enabled = false;
                letter_open = false;
                p_move.enabled = true;
            }
        }
    }

    public void image_pop_up(string[] parameters){
    	Debug.Log("image_pop_up");
    	letter.enabled = bool.Parse(parameters[0]);
    	Debug.Log(bool.Parse(parameters[0]));
    	letter_open = true;
    	// letter_close();
    }

    // public void letter_close(){
    // 	Debug.Log("in letter_close");
    // 	if(letter.enabled == true){
    // 		if(Input.GetKeyDown(KeyCode.Space)){
    // 			letter.enabled = false;
    // 			playerMovement.letter_open = false;
    // 		}
    // 	}
    // }


}

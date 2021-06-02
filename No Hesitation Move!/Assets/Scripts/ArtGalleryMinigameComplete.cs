using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ArtGalleryMinigameComplete : MonoBehaviour
{

	public GameObject owl;
	public GameObject romeo;

	public DialogueRunner diaRun;
	public YarnProgram scriptToLoad;
	public string talktonode;
    public Sprite speaking_sprite;
    Animator romeo_animator;
    SpriteRenderer romeo_sprite;
    playerMovement p_movement;

    void Awake()
    {
        diaRun = FindObjectOfType<DialogueRunner>();
        diaRun.AddCommandHandler("enable_animator", enable_animator);
    }

    // Start is called before the first frame update
    void Start()
    {
        romeo_sprite = romeo.GetComponent<SpriteRenderer>();
        romeo_animator = romeo.GetComponent<Animator>();
		talktonode = "Start";
        p_movement = romeo.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(GlobalVars.rc_has_spoken == false){
    		start_grifton_dialogue();
    	}

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            romeo_animator.enabled = true;
            p_movement.enabled = true;
        }
    }

    public void start_grifton_dialogue(){
    	// yield return new WaitForSecondsRealtime(1.0f);
    	if(GlobalVars.rc_hasCollect == true)
    	{
			owl.transform.position = new Vector3 (7.25f, 3.6f, 0.0f);
    		romeo.transform.position = new Vector3 (6.0f, 3.45f, 0.0f);
            p_movement.enabled = false;
            romeo_animator.enabled = false;
            romeo_sprite.sprite = speaking_sprite;
    		diaRun.Add(scriptToLoad);
    		diaRun.StartDialogue(talktonode);
    		GlobalVars.rc_has_spoken = true;

    	}
    	
    	// yield return null;
    }

    public void enable_animator(string[] parameters)
    {
        romeo_animator.enabled = true;
        p_movement.enabled = true;
    }
}

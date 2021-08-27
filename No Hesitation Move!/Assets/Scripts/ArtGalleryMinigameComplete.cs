using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ArtGalleryMinigameComplete : MonoBehaviour
{
    [Header("Character Components")]
	public GameObject owl;
	public GameObject romeo;
    Animator romeo_animator;
    SpriteRenderer romeo_sprite;
    playerMovement p_move;

    [Header("Yarnspinner Components")]
	public DialogueRunner diaRun;
	public YarnProgram scriptToLoad;
	public string talktonode;
    public Sprite speaking_sprite;
    
    [Header("Spawn Components")]
    public GameObject romeo_spawn;
    public GameObject owl_spawn;

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
        p_move = romeo.GetComponent<playerMovement>();
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
            p_move.enabled = true;
        }
    }

    public void start_grifton_dialogue(){
    	// yield return new WaitForSecondsRealtime(1.0f);
    	if(GlobalVars.rc_hasCollect == true)
    	{
    		romeo.transform.position = romeo_spawn.transform.position;
            owl.transform.position = owl_spawn.transform.position;
            p_move.anim.SetFloat("Horizontal", 1.0f);
            p_move.anim.SetFloat("Speed", 0.0f);
            p_move.enabled = false;
    		diaRun.Add(scriptToLoad);
    		diaRun.StartDialogue(talktonode);
    		GlobalVars.rc_has_spoken = true;

    	}
    	
    	// yield return null;
    }

    public void enable_animator(string[] parameters)
    {
        p_move.enabled = true;
    }
}

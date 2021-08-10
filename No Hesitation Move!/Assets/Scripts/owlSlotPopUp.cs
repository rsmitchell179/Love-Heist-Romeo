using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class owlSlotPopUp : MonoBehaviour
{
	[Header("Slot Bubble")]
	public Image slot_machine;
	public Image bubble;

	[Header("Character Components")]
	public GameObject owl;
	public GameObject romeo;
	playerMovement p_movement;
	SpriteRenderer romeo_sprite;
	Animator romeo_animator;
	
	[Header("Yarnspinner Components")]
	public YarnProgram scriptToLoad;
	public DialogueRunner diaRun = null;
	public string talktonode;

	[Header("UI Components")]
	public Camera cam;
	public GameObject slot_canvas;
	public Image img_fade;

	[Header("Sprites")]
	public Sprite speaking_sprite;

	void Awake()
	{
		talktonode = "Start";
		diaRun = FindObjectOfType<DialogueRunner>();
		romeo_sprite = romeo.GetComponent<SpriteRenderer>();
		romeo_animator = romeo.GetComponent<Animator>();
		diaRun.AddCommandHandler("enable_p_movement", enable_p_movement);
		img_fade.CrossFadeAlpha(0, 0f, true);
	}

    // Start is called before the first frame update
    void Start()
    {
        p_movement = romeo.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(GlobalVars.ft_hasCollect == false)
    	{
			bubble.enabled = true;
			slot_machine.enabled = true;
			set_pos(bubble);
			set_pos(slot_machine);
    	}
    	else
    	{
    		bubble.enabled = false;
			slot_machine.enabled = false;
			// slot_canvas.SetActive(false);
    	}

    	if(Input.GetKeyDown(KeyCode.Tab))
    	{
    		romeo_animator.enabled = true;
    		p_movement.enabled = true;
    	}
    }

    public void start_owl_dialogue()
    {
    	GlobalVars.ft_hasCollect = true;
    	StartCoroutine(start_owl_scene());

    }

    IEnumerator start_owl_scene()
    {
    	yield return new WaitForSecondsRealtime(1.5f);

    	img_fade.CrossFadeAlpha(1, 0.5f, false);

    	yield return new WaitForSecondsRealtime(1.0f);

    	romeo.transform.position = new Vector3(-5.7f, -5.5f, 0.0f);
    	owl.transform.position = new Vector3(-4.4f, -5.375f, 0.0f);
    	romeo_sprite.sprite = speaking_sprite;
    	p_movement.anim.SetFloat("Speed", 0.0f);
    	p_movement.anim.SetFloat("Horizontal", 1.0f);

    	yield return new WaitForSecondsRealtime(0.5f);

    	img_fade.CrossFadeAlpha(0, 0.5f, false);

    	yield return new WaitForSecondsRealtime(0.7f);

    	diaRun.Add(scriptToLoad);
    	diaRun.StartDialogue(talktonode);
    }

    void set_pos(Image bub)
    {
    	float y_offset = owl.GetComponent<SpriteRenderer>().bounds.max.y + 0.5f;
    	Vector3 bub_position = new Vector3(owl.transform.position.x, y_offset, owl.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }

    public void enable_p_movement(string[] parameters)
    {
    	p_movement.enabled = true;
    }
}

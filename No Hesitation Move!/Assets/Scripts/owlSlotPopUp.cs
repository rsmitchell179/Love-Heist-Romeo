using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class owlSlotPopUp : MonoBehaviour
{

	public Image slot_machine;
	public Image bubble;

	public GameObject owl;
	public GameObject romeo;
	public Camera cam;

	public YarnProgram scriptToLoad;
	public DialogueRunner diaRun = null;
	public string talktonode;
	public GameObject slot_canvas;

	void Awake()
	{
		talktonode = "Start";
		diaRun = FindObjectOfType<DialogueRunner>();
	}

    // Start is called before the first frame update
    void Start()
    {
        
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
			slot_canvas.SetActive(false);
    	}
    }

    public void start_owl_dialogue()
    {
    	GlobalVars.ft_hasCollect = true;
    	romeo.transform.position = new Vector3(-5.95f, 0.35f, 0.0f);
    	owl.transform.position = new Vector3(-4.05f, 0.98f, 0.0f);
    	diaRun.Add(scriptToLoad);
    	diaRun.StartDialogue(talktonode);

    }

    void set_pos(Image bub)
    {
    	float y_offset = owl.GetComponent<SpriteRenderer>().bounds.max.y + 0.5f;
    	Vector3 bub_position = new Vector3(owl.transform.position.x, y_offset, owl.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }
}

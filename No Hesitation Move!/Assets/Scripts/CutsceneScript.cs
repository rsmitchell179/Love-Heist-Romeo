using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{

	[Header("Slideshow")]
	public Sprite[] frames;
	public SpriteRenderer curr_frame;
	public int frame_count = 0;
	private int next_frame_count = 0;

	[Header("Background")]
	public SpriteRenderer background;
	public Sprite[] alt_bkgr;
	public int bkgr_count = 0;
	private int next_bkgr_count = 0;

	[Header("Yarnspinner")]
	public DialogueRunner diaRun;
	public YarnProgram cutscene_text;
	public string talktonode;

	[Header("Next Scene")]
	public string next_scene = "";

	[Header("Character Boxes")]
	public Image romeo_box;
	public Image wiz_box;

	[Header("TMP Text")]
	public TMP_Text ui_text;
    public Color romeo_color = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    public Color wiz_color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color clear_color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

	void Awake()
	{
		diaRun = FindObjectOfType<DialogueRunner>();
		diaRun.AddCommandHandler("next_frame", next_frame);
		diaRun.AddCommandHandler("char_toggle", char_toggle);
		diaRun.AddCommandHandler("next_bkgr", next_bkgr);
	}

    // Start is called before the first frame update
    void Start()
    {
        diaRun.Add(cutscene_text);
		diaRun.StartDialogue(talktonode);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
        	SceneManager.LoadScene(next_scene);
        }
    }

    public void char_toggle(string[] parameters)
    {
    	string speaker = parameters[0];
    	if(string.Equals("wizard", speaker))
    	{
    		wiz_box.enabled = true;
    		ui_text.color = wiz_color;
    		romeo_box.enabled = false;
    	}
    	else if(string.Equals("romeo", speaker))
    	{
    		romeo_box.enabled = true;
    		ui_text.color = romeo_color;
    		wiz_box.enabled = false;
    	}
    	else if(string.Equals("none", speaker))
    	{
    		wiz_box.enabled = false;
    		romeo_box.enabled = false;
    		ui_text.color = clear_color;
    	}
    }

    public void next_frame(string[] parameters)
    {
    	if(frame_count < frames.Length-1)
    	{
    		next_frame_count = Int32.Parse(parameters[0]);
    		frame_count = frame_count + next_frame_count;
    		curr_frame.sprite = frames[frame_count];
    	}
    	else
    	{
    		SceneManager.LoadScene(next_scene);
    	}
    }

    public void next_bkgr(string[] parameters)
    {
    	if(bkgr_count < alt_bkgr.Length)
    	{
    		next_bkgr_count = Int32.Parse(parameters[0]);
    		bkgr_count = bkgr_count + next_bkgr_count;
    		background.sprite = alt_bkgr[bkgr_count];
    	}
    }
}

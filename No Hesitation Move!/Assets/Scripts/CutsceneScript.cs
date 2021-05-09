using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{

	[Header("Slideshow")]
	public Sprite[] frames;
	public SpriteRenderer curr_frame;
	public int frame_count = 0;
	private int parse_param_int = 0;

	[Header("Yarnspinner")]
	public DialogueRunner diaRun;
	public YarnProgram cutscene_text;
	public string talktonode;

	[Header("Next Scene")]
	public string next_scene = "";

	void Awake()
	{
		diaRun = FindObjectOfType<DialogueRunner>();
		diaRun.AddCommandHandler("next_frame", next_frame);
		talktonode = "Cutscene_Dialogue";
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
        
    }

    public void next_frame(string[] parameters)
    {
    	if(frame_count < frames.Length-1)
    	{
    		parse_param_int = Int32.Parse(parameters[0]);
    		frame_count = frame_count + parse_param_int;
    		curr_frame.sprite = frames[frame_count];
    	}
    	else
    	{
    		SceneManager.LoadScene(next_scene);
    	}
    }
}

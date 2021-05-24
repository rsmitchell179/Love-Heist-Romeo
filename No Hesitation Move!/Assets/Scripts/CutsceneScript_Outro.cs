using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CutsceneScript_Outro : MonoBehaviour
{

	[Header("Slideshow")]
	public Sprite[] frames;
	public SpriteRenderer curr_frame;
	public int frame_count = 0;
	public int next_frame_count = 0;

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
    public Image romeo_yell;

	[Header("TMP Text")]
	public TMP_Text ui_text;
    public float text_size;
    public Color romeo_color = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    public Color wiz_color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color clear_color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    [Header("Beams")]
    public SpriteRenderer beams;
    public Sprite[] alt_beams;
    public int beam_count = 0;
    public int next_beam_count = 0;

    [Header("Orbs")]
    public GameObject orbs;
    public GameObject[] alt_orbs;
    public int orb_count = 0;
    public int next_orb_count = 0;

    private string scene_to_load;

    [Header("Credits")]
    public Image credits;

	void Awake()
	{
		diaRun = FindObjectOfType<DialogueRunner>();
		diaRun.AddCommandHandler("next_frame", next_frame);
		diaRun.AddCommandHandler("char_toggle", char_toggle);
		diaRun.AddCommandHandler("next_bkgr", next_bkgr);
        diaRun.AddCommandHandler("font_size", font_size);
        diaRun.AddCommandHandler("enable_beam", enable_beam);
        diaRun.AddCommandHandler("next_beam", next_beam);
        diaRun.AddCommandHandler("enable_orbs", enable_orbs);
        diaRun.AddCommandHandler("next_orbs", next_orbs);
        diaRun.AddCommandHandler("finish_beams",  finish_beams);
        diaRun.AddCommandHandler("enable_romeo_textbox", enable_romeo_textbox);
        diaRun.AddCommandHandler("enable_credits", enable_credits);
	}

    // Start is called before the first frame update
    void Start()
    {
        diaRun.Add(cutscene_text);
		diaRun.StartDialogue(talktonode);
		// orbs.SetActive(false);
		beams.enabled = false;
        credits.enabled = false;
		scene_to_load = "TitleScreen";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
        	SceneManager.LoadScene(next_scene);
        }
    }

    public void char_toggle(string[] parameters) // Toggles who is speaking, or whether anyone is speaking
    {
    	string speaker = parameters[0];
    	if(string.Equals("wizard", speaker))     // <<char_toggle wizard>> to have the wizard speak
    	{
    		wiz_box.enabled = true;
    		ui_text.color = wiz_color;
    		romeo_box.enabled = false;
            romeo_yell.enabled = false;
    	}
    	else if(string.Equals("romeo", speaker)) // <<char_toggle romeo>> to have romeo speaking
    	{
    		romeo_box.enabled = true;
    		ui_text.color = romeo_color;
    		wiz_box.enabled = false;
            romeo_yell.enabled = true;
    	}
    	else if(string.Equals("none", speaker))  // <<char_toggle none>> to have the scene empty
    	{
    		wiz_box.enabled = false;
    		romeo_box.enabled = false;
    		ui_text.color = clear_color;
            romeo_yell.enabled = false;
    	}
    }

    public void next_frame(string[] parameters)  // <<next_frame 1>> switches to the next frame in the array
    {
    	if(parameters[0] == "next")
    	{
    		SceneManager.LoadScene(scene_to_load);
    	}
    	else
    	{
    		next_frame_count = Int32.Parse(parameters[0]);
    		curr_frame.sprite = frames[next_frame_count];
    	}
    }

    public void next_bkgr(string[] parameters)   // <<next_bkgr 1>> switches to the next background in the array
    {
    	if(bkgr_count < alt_bkgr.Length)
    	{
    		next_bkgr_count = Int32.Parse(parameters[0]);
    		bkgr_count = bkgr_count + next_bkgr_count;
    		background.sprite = alt_bkgr[bkgr_count];
    	}
    }

    public void font_size(string[] parameters)   // <<font_size [font size]>> changes font size, 
    {                                            // note: any change in font size will need to be
        text_size = float.Parse(parameters[0]);  // changed back to the original size, 25.
        ui_text.fontSize = text_size;
    }

    public void enable_beam(string[] parameters)
    {
    	beams.enabled = bool.Parse(parameters[0]);
    	// Debug.Log("enable beams");
    }

    public void next_beam(string[] parameters)
    {
    	if(beam_count < alt_beams.Length)
    	{
    		next_beam_count = Int32.Parse(parameters[0]);
    		beam_count = beam_count + next_beam_count;
    		beams.sprite = alt_beams[beam_count];
    	}
    }

    public void enable_orbs(string[] parameters)
    {
    	orbs.SetActive(bool.Parse(parameters[0]));
    }

    public void next_orbs(string[] parameters)
    {

    	if(orb_count > 0)
    	{
    		Debug.Log("orbcount > 0");
    		alt_orbs[orb_count-1].SetActive(false);
    	}

    	alt_orbs[orb_count].SetActive(true);
    	next_orb_count = Int32.Parse(parameters[0]);
    	orb_count = orb_count + next_orb_count;
    }

    public void finish_beams(string[] parameters, System.Action onComplete)
    {
    	StartCoroutine(finish_final_beams(onComplete));
    }

    IEnumerator finish_final_beams(System.Action onComplete)
    {
    	yield return new WaitForSecondsRealtime(0.5f);

    	beam_count++;
    	beams.sprite = alt_beams[beam_count];

    	yield return new WaitForSecondsRealtime(1.0f);

    	beams.enabled = false;

    	yield return new WaitForSecondsRealtime(0.5f);

    	onComplete();
    }

    public void enable_romeo_textbox(string[] parameters)
    {
    	romeo_box.enabled = bool.Parse(parameters[0]);
    }

    public void enable_credits(string[] parameters, System.Action onComplete)
    {

        StartCoroutine(credits_wait(onComplete));
    }

    IEnumerator credits_wait(System.Action onComplete)
    {
        credits.enabled = true;

        yield return new WaitForSecondsRealtime(3.0f);

        onComplete();
    }
}

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

    [Header("Fade")]
    public Image img_fade;
   	private float fade_in_time = 0.3f;
   	private float fade_out_time = 0.5f;
    private float first_wait_time = 0.5f;
    private float second_wait_time = 1.3f;
    private float third_wait_time = 1.0f;
    private float fourth_wait_time = 1.0f;
    public bool is_fading;

	void Awake()
	{
		diaRun = FindObjectOfType<DialogueRunner>();
		diaRun.AddCommandHandler("next_frame", next_frame);
		diaRun.AddCommandHandler("char_toggle", char_toggle);
		diaRun.AddCommandHandler("next_bkgr", next_bkgr);
        diaRun.AddCommandHandler("font_size", font_size);
        diaRun.AddCommandHandler("enable_romeo_yell", enable_romeo_yell);
        diaRun.AddCommandHandler("start_fade", start_fade);

        img_fade.CrossFadeAlpha(0, 0.0f, true);
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

        if(is_fading == true)
        {
        	img_fade.CrossFadeAlpha(1, fade_in_time, false);
        }
        
        if(is_fading == false)
        {
        	img_fade.CrossFadeAlpha(0, fade_out_time, false);
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
    		SceneManager.LoadScene(next_scene);
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

    public void enable_romeo_yell(string[] parameters)
    {
    	romeo_yell.enabled = bool.Parse(parameters[0]);
    }

    public void start_fade(string[] parameters, System.Action onComplete)
    {
    	StartCoroutine(fade_routine(onComplete));
    }

    IEnumerator fade_routine(System.Action onComplete)
    {

    	yield return new WaitForSecondsRealtime(first_wait_time);

    	is_fading = true;

    	yield return new WaitForSecondsRealtime(second_wait_time);

    	wiz_box.enabled = false;
    	romeo_box.enabled = false;
		ui_text.color = clear_color;
        romeo_yell.enabled = false;

    	bkgr_count++;
    	background.sprite = alt_bkgr[bkgr_count];

		next_frame_count++;
		curr_frame.sprite = frames[next_frame_count];
		Debug.Log(next_frame_count);

    	yield return new WaitForSecondsRealtime(third_wait_time);

    	is_fading = false;

    	yield return new WaitForSecondsRealtime(fourth_wait_time);

    	onComplete(); 
    }
}

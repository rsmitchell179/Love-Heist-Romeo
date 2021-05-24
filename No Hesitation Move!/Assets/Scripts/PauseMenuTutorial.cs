using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class PauseMenuTutorial : MonoBehaviour
{

	[Header("Menus")]
    public GameObject pause_menu;
    public GameObject settings_menu;
    public GameObject tutorial_menu;

    [Header("Tutorial")]
    public Image background;
    public Image tutorial;
    public Sprite[] tutorial_slides;
    public int tutorial_frame;
    private float first_wait_time = 0.1f;
    private float second_wait_time = 0.5f;
    public bool after_fade;

    public Button heist_button;

    DialogueRunner diaRun;

    void Awake()
    {
    	tutorial.enabled = false;
    	background.enabled = false;
    	tutorial_menu.SetActive(false);
    	diaRun = FindObjectOfType<DialogueRunner>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(after_fade == true)
        {
        	if(Input.GetKeyDown(KeyCode.Space))
        	{
        		if(tutorial_frame < tutorial_slides.Length-1)
        		{
        			tutorial_frame++;
        			tutorial.sprite = tutorial_slides[tutorial_frame];
        		}
        		else
        		{
        			StartCoroutine(stop_slides());
        			after_fade = false;
        		}
        	}
        }
    }

    public void switch_to_tutorial()
    {
    	Debug.Log("inside switch_to_tutorial");
    	// diaRun.enabled = false;
    	diaRun.Stop();
    	tutorial_menu.SetActive(true);
    	Time.timeScale = 0f;
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(false);

    	StartCoroutine(start_slides());
    }

    IEnumerator start_slides()
    {
    	Debug.Log("inside start_slides");

    	yield return new WaitForSecondsRealtime(first_wait_time);

    	background.enabled = true;
    	tutorial.enabled = true;

    	yield return new WaitForSecondsRealtime(second_wait_time);

    	after_fade = true;
    }

    IEnumerator stop_slides()
    {
    	Debug.Log("inside stop_slides");

    	yield return new WaitForSecondsRealtime(second_wait_time);

    	switch_to_pause();
    }

    public void switch_to_pause()
    {
    	pause_menu.SetActive(true);
    	settings_menu.SetActive(false);
    	tutorial_menu.SetActive(false);

    	heist_button.Select();
    	heist_button.OnSelect(null);

    	tutorial_frame = 0;
    	tutorial.sprite = tutorial_slides[tutorial_frame];
    }
}

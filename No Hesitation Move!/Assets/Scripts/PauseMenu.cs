using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Yarn.Unity;

public class PauseMenu : MonoBehaviour
{
	[Header("Is The Game Paused")]
    public static bool is_paused = false;

    [Header("Menus")]
    public GameObject pause_menu;
    public GameObject settings_menu;

    [Header("Player Movement Script")]
    public playerMovement p_move;

    [Header("UI Components")]
    public GameObject resume_button;
    public TMPro.TMP_Dropdown reso_dropdown;
    public GameObject music_slider;
    public Image background;

    [Header("Audio Mixers")]
    public AudioMixer music_mix;
    public AudioMixer sfx_mix;

    [Header("Is The Cursor Visible")]
    public bool cursor_visible = false;

    Resolution[] reso;
    string main_menu_scene;
    GameObject last_button;
    DialogueRunner diaRun;
    DialogueUI diaUI;

    void Awake()
    {
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(false);
        diaRun = FindObjectOfType<DialogueRunner>();
        diaUI = FindObjectOfType<DialogueUI>();
    }

    void Start()
    {
    	main_menu_scene = "TitleScreen";
        
        reso = Screen.resolutions;
        reso_dropdown.ClearOptions();
        int curr_reso = 0;
        List<string> reso_options = new List<string>();
        for(int i = 0; i < reso.Length; i++)
        {
        	
        	string reso_option = reso[i].width + " x " + reso[i].height + ", " + reso[i].refreshRate + "hz";
        	reso_options.Add(reso_option);

        	if(reso[i].width == Screen.width && reso[i].height == Screen.height){
        		curr_reso = i;
        	}
        }

        reso_dropdown.AddOptions(reso_options);
        reso_dropdown.value = curr_reso;
        reso_dropdown.RefreshShownValue();

    }
    

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.Escape))
    	{
    		// Debug.Log("pause");
    		if(is_paused == false)
    		{
    			pause_game();
    		}
    		else
    		{
    			resume_game();
    		}
    	}

    	if(cursor_visible == true)
    	{
    		Cursor.visible = true;
    		Cursor.lockState = CursorLockMode.None;
    	}
    	else
    	{
    		Cursor.visible = false;
    		Cursor.lockState = CursorLockMode.Locked;
    	}

    	if(EventSystem.current.currentSelectedGameObject == null)
        {
        	EventSystem.current.SetSelectedGameObject(resume_button);
        }
        else
        {
        	last_button = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void save_game()
    {
        Debug.Log("SAVING DATA...");
        p_move.save_position();
        SaveSys.save_data();
    }

    public void pause_game()
    {
    	stop_game();
    	cursor_visible = false;
    	pause_menu.SetActive(true);
    	settings_menu.SetActive(false);
    	EventSystem.current.SetSelectedGameObject(null);
    }

    public void resume_game()
    {
    	start_game();
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(false);
    	EventSystem.current.SetSelectedGameObject(resume_button);
    	cursor_visible = false;
    }

    public void settings()
    {
    	stop_game();
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(true);
    	EventSystem.current.SetSelectedGameObject(music_slider);
    	cursor_visible = true;
    }

    public void quit_game()
    {
    	Debug.Log("quitter");
    	Application.Quit();
    }

    // general operations that are required in multiple buttons
    private void stop_game()
    {
    	background.enabled = true;
    	is_paused = true;
    	p_move.enabled = false;
    	Time.timeScale = 0f;
        // diaUI.DialogueComplete();
        // diaRun.Stop();
    }

	// general operations that are required in multiple buttons
    private void start_game()
    {
    	background.enabled = false;
    	is_paused = false;
    	p_move.enabled = true;
    	Time.timeScale = 1f;
    }

    public void main_menu()
    {
    	background.enabled = false;
        is_paused = false;
        pause_menu.SetActive(false);
        settings_menu.SetActive(false);
        p_move.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(main_menu_scene);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    	EventSystem.current.SetSelectedGameObject(last_button);
    }

    // Settings Menu Stuff

    public void set_music_volume(float volume)
    {
      if(volume <= 0){
    	music_mix.SetFloat("music", volume);
        }
        
    }

    public void set_sfx_volume(float volume)
    {
       if(volume <= 0){
    	sfx_mix.SetFloat("sfx", volume);
        }
    }

    public void set_reso(int reso_index)
    {
    	Resolution reso_t = reso[reso_index];
    	Screen.SetResolution(reso_t.width, reso_t.height, Screen.fullScreen);
    }

    public void set_full(bool is_full)
    {
    	Screen.fullScreen = is_full;
    }

    public void back_button()
    {
    	stop_game();
    	settings_menu.SetActive(false);
    	pause_menu.SetActive(true);
    	EventSystem.current.SetSelectedGameObject(resume_button);
    	cursor_visible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool is_paused = false;
    public GameObject pause_menu;
    public playerMovement p_move;
    public GameObject resume_button;
    public string main_menu_scene;
    public Image background;

    public GameObject settings_menu;
    public AudioMixer music_mix;
    public AudioMixer sfx_mix;

    void Awake()
    {
        main_menu_scene = "TitleScreen";
        background.enabled = false;
        settings_menu.SetActive(false);
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

    	// if(EventSystem.current.currentSelectedGameObject == null)
     //    {
     //    	EventSystem.current.SetSelectedGameObject(resume_button);
     //    }
    }

    public void save_game()
    {
        Debug.Log("SAVING DATA...");
        p_move.save_position();
        SaveSys.save_data();
        // GlobalVars.print_array();
    }

    public void pause_game()
    {
    	background.enabled = true;
    	is_paused = true;
    	pause_menu.SetActive(true);
    	p_move.enabled = false;
    	Time.timeScale = 0f;
    	EventSystem.current.SetSelectedGameObject(resume_button);
    }

    public void resume_game()
    {
    	background.enabled = false;
    	is_paused = false;
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(false);
    	p_move.enabled = true;
    	Time.timeScale = 1f;
    	EventSystem.current.SetSelectedGameObject(null);
    }

    public void settings()
    {
    	background.enabled = true;
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(true);
    	p_move.enabled = false;
    	Time.timeScale = 0f;
    	settings_menu.SetActive(true);
    }

    public void quit_game()
    {
    	Debug.Log("quitter");
    	Application.Quit();
    }

    public void main_menu()
    {
    	background.enabled = false;
        is_paused = false;
        pause_menu.SetActive(false);
        settings_menu.SetActive(false);
        p_move.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    // Settings Menu Stuff

    public void set_music_volume(float volume)
    {
    	music_mix.SetFloat("music", volume);
    }

    public void set_sfx_volume(float volume)
    {
    	sfx_mix.SetFloat("sfx", volume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool is_paused = false;
    public GameObject pause_menu;
    public playerMovement p_move;
    public GameObject resume_button;
    public string main_menu_scene;

    void Awake()
    {
        main_menu_scene = "TitleScreen";
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.Escape))
    	{
    		Debug.Log("pause");
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
    	is_paused = true;
    	pause_menu.SetActive(true);
    	p_move.enabled = false;
    	Time.timeScale = 0f;
    	EventSystem.current.SetSelectedGameObject(resume_button);
    }

    public void resume_game()
    {
    	is_paused = false;
    	pause_menu.SetActive(false);
    	p_move.enabled = true;
    	Time.timeScale = 1f;
    	EventSystem.current.SetSelectedGameObject(null);
    }

    public void quit_game()
    {
    	Debug.Log("quitter");
    	Application.Quit();
    }

    public void main_menu()
    {
        is_paused = false;
        pause_menu.SetActive(false);
        p_move.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}

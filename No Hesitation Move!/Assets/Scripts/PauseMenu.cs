using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Yarn.Unity;
using TMPro;

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
    public float default_volume;

    [Header("Is The Cursor Visible")]
    public bool cursor_visible = false;

    [Header("Resolution Components")]
    Resolution[] all_resolutions;
    List<string> reso_options;
    List<Resolution> selected_resolutions;
    Resolution[] final_resolutions;
    int curr_resolution;

    string main_menu_scene;
    GameObject last_button;
    DialogueRunner diaRun;
    DialogueUI diaUI;
    public TMP_Text save_prompt_text;

    [Header("Sliders")]
    public Slider m_slider;
    public Slider s_slider;

    void Awake()
    {   
        /* Turn off canvases initially */
    	pause_menu.SetActive(false);
    	settings_menu.SetActive(false);

        /* Find Yarnspinner stuff */ 
        diaRun = FindObjectOfType<DialogueRunner>();
        diaUI = FindObjectOfType<DialogueUI>();
        save_prompt_text.CrossFadeAlpha(0.0f, 0.0f, false);

        curr_resolution = PlayerPrefs.GetInt("dropdown_index");
        // Debug.Log("curr_resolution is now " + curr_resolution);
    }

    void Start()
    {
    	main_menu_scene = "TitleScreen";

        /* get the aspect ratios for filtering */
        float reso_1 = 16f / 9f;
        float reso_2 = 16f / 10f;

        all_resolutions = Screen.resolutions;
        List<Resolution> selected_resolutions = new List<Resolution>();
        reso_dropdown.ClearOptions();
        List<string> reso_options = new List<string>();
        for(int i = 0; i < all_resolutions.Length; i++)
        {
        	string reso_option = all_resolutions[i].width + " x " + all_resolutions[i].height + ", " + all_resolutions[i].refreshRate + "hz";

            /* For Debugging, seeing current resolution ratio */
            // Debug.Log((float)all_resolutions[i].width / (float)all_resolutions[i].height);

            if(((float)((float)all_resolutions[i].width / (float)all_resolutions[i].height) == reso_1)){
                selected_resolutions.Add(all_resolutions[i]);
                reso_options.Add(reso_option);
            }
            else if(((float)((float)all_resolutions[i].width / (float)all_resolutions[i].height) == reso_2))
            {
                selected_resolutions.Add(all_resolutions[i]);
                reso_options.Add(reso_option);
            }
            else
            {
                continue;
            }

            // if(all_resolutions[i].refreshRate > 61 || all_resolutions[i].refreshRate < 59){
            //     continue;
            // }

            // selected_resolutions.Add(all_resolutions[i]);
            // reso_options.Add(reso_option);
        }

        /* do this whack ass conversion bc the list wasn't working */
        final_resolutions = new Resolution[selected_resolutions.Count];
        for(int i = 0; i < selected_resolutions.Count; i++)
        {
            final_resolutions[i] = selected_resolutions[i];
        }

        reso_dropdown.AddOptions(reso_options);
        reso_dropdown.value = curr_resolution;
        reso_dropdown.RefreshShownValue();

        if(PlayerPrefs.HasKey("music_volume"))
        {
            float set_m_volume = PlayerPrefs.GetFloat("music_volume");
            m_slider.value = set_m_volume;
        }
        else
        {
            PlayerPrefs.SetFloat("music_volume", default_volume);
            m_slider.value = default_volume;
            PlayerPrefs.Save();
        }

        if(PlayerPrefs.HasKey("sfx_volume"))
        {
            float set_s_volume = PlayerPrefs.GetFloat("sfx_volume");
            s_slider.value = set_s_volume;
        }
        else
        {
            PlayerPrefs.SetFloat("sfx_volume", default_volume);
            s_slider.value = default_volume;
            PlayerPrefs.Save();
        }
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

        // if(Input.GetKeyDown(KeyCode.Backslash))
        // {
        //     PlayerPrefs.DeleteKey("music_volume");
        //     PlayerPrefs.DeleteKey("sfx_volume");
        // }
    }

    IEnumerator SavePrompt() {
    	// save_prompt_text.enabled = true;
        save_prompt_text.CrossFadeAlpha(1.0f, 0.5f, true);
        yield return new WaitForSecondsRealtime(2.5f);
        save_prompt_text.CrossFadeAlpha(0.0f, 1.0f, true);
    	// save_prompt_text.enabled = false;
    }

    public void save_game()
    {
        Debug.Log("SAVING DATA...");
        p_move.save_position();
        SaveSys.save_data();
        StartCoroutine(SavePrompt());
    }

    public void pause_game()
    {
    	stop_game();
    	cursor_visible = false;
    	pause_menu.SetActive(true);
    	settings_menu.SetActive(false);
    	EventSystem.current.SetSelectedGameObject(null);
        save_prompt_text.CrossFadeAlpha(0.0f, 0.0f, false);
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
        save_prompt_text.CrossFadeAlpha(0.0f, 0.0f, false);
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
        float logVolume = Mathf.Log10(volume) * 20;
    	music_mix.SetFloat("music", logVolume);
        PlayerPrefs.SetFloat("music_volume", volume);
        PlayerPrefs.Save(); 
    }

    public void set_sfx_volume(float volume)
    {
        float logVolume = Mathf.Log10(volume) * 20;
    	sfx_mix.SetFloat("sfx", logVolume);
        PlayerPrefs.SetFloat("sfx_volume", volume);
        PlayerPrefs.Save();
    }

    public void set_reso(int reso_index)
    {
    	Resolution reso_t = final_resolutions[reso_index];
        Screen.SetResolution(reso_t.width, reso_t.height, Screen.fullScreen);
        PlayerPrefs.SetInt("dropdown_index", reso_index);
        PlayerPrefs.Save();
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

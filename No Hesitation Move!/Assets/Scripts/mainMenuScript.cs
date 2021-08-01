using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class mainMenuScript : MonoBehaviour {
	
    public string newGameScene;
    private GameObject last_button;
    public GameObject titleCloud;
    public GameObject star1;
    public GameObject star2;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject quitGameButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject settingsCloud;
    public GameObject musicSlider;
    public GameObject sfxSlider;
    public GameObject resolutionDropdown;
    public GameObject fullscreenToggle;
    public GameObject back_ButtonS;
    public Button settings_Button;
    public Button credits_Button;
    public Button back_ButtonC;
    public Slider music_slider;
    public GameObject creditsBg;
    public GameObject creditsWords;
    public GameObject backToMenuC;

    [Header("Audio Mixers")]
    public AudioMixer music_mix;
    public AudioMixer sfx_mix;

    [Header("Sliders")]
    public Slider m_slider;
    public Slider s_slider;

    [Header("Dropdown")]
    public TMPro.TMP_Dropdown reso_dropdown;
    Resolution[] all_resolutions;
    List<string> reso_options;
    List<Resolution> selected_resolutions;
    Resolution[] final_resolutions;
    int curr_resolution;

    void Awake()
    {
        curr_resolution = PlayerPrefs.GetInt("dropdown_index", 2);
        Debug.Log("curr_resolution is now " + curr_resolution);
    }

    // Start is called before the first frame update
    void Start() {

        /* get the quotient ratio of 1920 x 1080 resolutions for comparisons later */
        float reso_temp = 1920f / 1080f;

        all_resolutions = Screen.resolutions;
        List<Resolution> selected_resolutions = new List<Resolution>();
        reso_dropdown.ClearOptions();
        List<string> reso_options = new List<string>();
        for(int i = 0; i < all_resolutions.Length; i++)
        {
            string reso_option = all_resolutions[i].width + " x " + all_resolutions[i].height + ", " + all_resolutions[i].refreshRate + "hz";

            /* For Debugging, seeing current resolution ratio */
            // Debug.Log((float)all_resolutions[i].width / (float)all_resolutions[i].height);

            if(((float)((float)all_resolutions[i].width / (float)all_resolutions[i].height) != reso_temp)){
                continue;
            }

            // if(all_resolutions[i].refreshRate > 61 || all_resolutions[i].refreshRate < 59){
            //     continue;
            // }

            selected_resolutions.Add(all_resolutions[i]);
            reso_options.Add(reso_option);
        }

        /* do this whack ass conversion bc the list wasn't working */
        final_resolutions = new Resolution[selected_resolutions.Count];
        for(int i = 0; i < selected_resolutions.Count; i++)
        {
            final_resolutions[i] = selected_resolutions[i];
            // Debug.Log(final_resolutions[i]);
        }

        reso_dropdown.AddOptions(reso_options);

        Debug.Log(curr_resolution);
        reso_dropdown.value = curr_resolution;
        reso_dropdown.RefreshShownValue();
        
        float set_m_volume = PlayerPrefs.GetFloat("music_volume");
        m_slider.value = set_m_volume;
        float set_s_volume = PlayerPrefs.GetFloat("sfx_volume");
        s_slider.value = set_s_volume;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.RightArrow)) {
        	gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
        }

        if(EventSystem.current.currentSelectedGameObject == null)
        {
        	EventSystem.current.SetSelectedGameObject(last_button);
        }
        else
        {
        	last_button = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void Settings() {
    	Cursor.visible = true;
    	Cursor.lockState = CursorLockMode.None;
    	titleCloud.SetActive(false);
    	star1.SetActive(false);
		star2.SetActive(false);
		newGameButton.SetActive(false);
		loadGameButton.SetActive(false);
		quitGameButton.SetActive(false);
		settingsButton.SetActive(false);
		creditsButton.SetActive(false);
		settingsCloud.SetActive(true);
		musicSlider.SetActive(true);
		sfxSlider.SetActive(true);
		resolutionDropdown.SetActive(true);
		fullscreenToggle.SetActive(true);
		back_ButtonS.SetActive(true);
		music_slider.Select();
    }
    public void backToMainMenuS() {
    	titleCloud.SetActive(true);
    	star1.SetActive(true);
		star2.SetActive(true);
		newGameButton.SetActive(true);
		loadGameButton.SetActive(true);
		quitGameButton.SetActive(true);
		settingsButton.SetActive(true);
		creditsButton.SetActive(true);
		settingsCloud.SetActive(false);
		musicSlider.SetActive(false);
		sfxSlider.SetActive(false);
		resolutionDropdown.SetActive(false);
		fullscreenToggle.SetActive(false);
		back_ButtonS.SetActive(false);
		Cursor.visible = false;
		settings_Button.Select();
    }
    public void credits() {
        titleCloud.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        newGameButton.SetActive(false);
        loadGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);
        creditsBg.SetActive(true);
        creditsWords.SetActive(true);
        backToMenuC.SetActive(true);
        back_ButtonC.Select();
    }
    public void backToMainMenuC() {
        titleCloud.SetActive(true);
        star1.SetActive(true);
        star2.SetActive(true);
        newGameButton.SetActive(true);
        loadGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        settingsButton.SetActive(true);
        creditsButton.SetActive(true);
        creditsBg.SetActive(false);
        creditsWords.SetActive(false);
        backToMenuC.SetActive(false);
        credits_Button.Select();
    }
    public void set_music_volume(float volume)
    {
    	music_mix.SetFloat("music", volume);
        PlayerPrefs.SetFloat("music_volume", volume);
        PlayerPrefs.Save(); 
    }

    public void set_sfx_volume(float volume)
    {
    	sfx_mix.SetFloat("sfx", volume);
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
}

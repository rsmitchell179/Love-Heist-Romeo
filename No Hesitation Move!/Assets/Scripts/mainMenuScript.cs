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

    // Start is called before the first frame update
    void Start() {
        
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
    	titleCloud.SetActive(false);
    	star1.SetActive(false);
		star2.SetActive(false);
		newGameButton.SetActive(false);
		loadGameButton.SetActive(false);
		quitGameButton.SetActive(false);
		settingsButton.SetActive(false);
		creditsButton.SetActive(false);
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
		musicSlider.SetActive(false);
		sfxSlider.SetActive(false);
		resolutionDropdown.SetActive(false);
		fullscreenToggle.SetActive(false);
		back_ButtonS.SetActive(false);
		Cursor.visible = false;
		settings_Button.Select();
    }
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
}

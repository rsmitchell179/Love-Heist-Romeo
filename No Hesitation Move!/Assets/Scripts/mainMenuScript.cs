using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenuScript : MonoBehaviour {
	
    public string newGameScene;
    private GameObject last_button;
    public Canvas menuCanvas;
    public Canvas settings;
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
        menuCanvas.enabled = false;
        settings.enabled = true;
    }
}

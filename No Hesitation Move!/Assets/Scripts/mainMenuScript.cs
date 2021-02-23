using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {
	
    public string newGameScene;

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
    }

    public void StartGame() {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame() {
        Application.Quit();
    }
}

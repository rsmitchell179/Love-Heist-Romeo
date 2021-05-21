using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLetters : MonoBehaviour {
	public SpriteRenderer letter;
	public Sprite letter_opened;
	public Sprite letter_closed;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
        	letter.sprite = letter_opened;
        }
    }
}

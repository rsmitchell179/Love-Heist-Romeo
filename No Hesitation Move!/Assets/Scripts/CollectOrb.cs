using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CollectOrb : MonoBehaviour {
	public Image JSOrbImage;
	public Image FTOrbImage;
	public Image RCOrbImage;
	public Sprite JSOrb;
	public Sprite FTOrb;
	public Sprite RCOrb;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // DontDestroyOnLoad(this);
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if(other.gameObject.CompareTag("JSOrb")) {
    		Destroy(other.gameObject);
    		playerMovement.hasJSorb = true;
    	}
    	if(other.gameObject.CompareTag("FTOrb")) {
    		Destroy(other.gameObject);
    		playerMovement.hasFTorb = true;
    	}
    	if(other.gameObject.CompareTag("RCOrb")) {
    		Destroy(other.gameObject);
    		playerMovement.hasRCorb = true;
    	}
    	if(playerMovement.hasJSorb) {
    		SetImage1();
    	}
    	if(playerMovement.hasFTorb) {
    		SetImage2();
    	}
    	if(playerMovement.hasRCorb) {
    		SetImage3();
    	}
    }
    public void SetImage1() {
    	JSOrbImage.sprite = JSOrb;
    }
    public void SetImage2() {
        FTOrbImage.sprite = FTOrb;
    }
    public void SetImage3() {
        RCOrbImage.sprite = RCOrb;
    }
}

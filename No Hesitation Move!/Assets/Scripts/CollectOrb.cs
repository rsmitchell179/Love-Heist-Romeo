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
        // for dev purposes
        // if(Input.GetKeyDown(KeyCode.I))
        // {
        //     GlobalVars.hasJSorb = true;
        //     SetImage1();
        // }

        // if(Input.GetKeyDown(KeyCode.O))
        // {
        //     GlobalVars.hasFTorb = true;
        //     SetImage2();
        // }

        // if(Input.GetKeyDown(KeyCode.P))
        // {
        //     GlobalVars.hasRCorb = true;
        //     SetImage3();
        // }

        if(GlobalVars.hasJSorb) {
    		SetImage1();
    	}
    	if(GlobalVars.hasFTorb) {
    		SetImage2();
    	}
    	if(GlobalVars.hasRCorb) {
    		SetImage3();
    	}
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if(other.gameObject.CompareTag("JSOrb")) {
    		Destroy(other.gameObject);
    		GlobalVars.hasJSorb = true;
    	}
    	if(other.gameObject.CompareTag("FTOrb")) {
    		Destroy(other.gameObject);
    		GlobalVars.hasFTorb = true;
    	}
    	// if(other.gameObject.CompareTag("RCOrb")) {
    	// 	Destroy(other.gameObject);
    	// 	GlobalVars.hasRCorb = true;
    	// }

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

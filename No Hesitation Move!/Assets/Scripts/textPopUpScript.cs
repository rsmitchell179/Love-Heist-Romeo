﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPopUpScript : MonoBehaviour
{

	public GameObject player;
	public GameObject guy1;
	public GameObject text;

	public 

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // var dist = Vector3.Distance(player.transform.position, guy1.transform.position);

        // if(){
        // 	lorum.SetActive(true);
        // 	Debug.Log("true");
        // }
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "Player"){
    		text.SetActive(true);
        	Debug.Log("true");
    	}
    }

    void OnTriggerExit2D(Collider2D other){
    	if(other.tag == "Player"){
    		text.SetActive(false);
        	Debug.Log("false");
    	}
    }

    // void FadeTextIn(){
    // 	Color color = text.color;

    // 	if(color.a > 255){
    // 		color.a = 255;
    // 	}

    // 	if(text.activeSelf){

    // 	}
    // }
    
}

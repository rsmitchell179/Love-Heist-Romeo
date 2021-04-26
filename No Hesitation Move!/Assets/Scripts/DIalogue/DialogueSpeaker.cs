﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class DialogueSpeaker : MonoBehaviour
{

    [Header("Dialogue Runner")]
    public DialogueRunner dialogueRunner;

    [Header("Character Portraits")]
    public Image romeo;
    public Image other_person;

    [Header("Character Boxes")]
    public Image romeo_box;
    public Image other_box;

    [Header("NPC Name")]
    public string npc_name = "";

    [Header("TMP Text")]
    public TMP_Text ui_text;
    public Color romeo_color = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    public Color rc_color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	
    public void Awake()
    {
        try{
            dialogueRunner.AddCommandHandler("set_speaker", set_speaker_in_scene);
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in DialogueSpeaker, don't worry about it for now");
            }
        // dialogueRunner.AddCommandHandler("set_speaker", set_speaker_in_scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        try{
            romeo.enabled = false;
        }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in DialogueSpeaker romeo.enabled, don't worry about it for now");
            }
        
        try{
            other_person.enabled = false;
        }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in DialogueSpeaker other_person.enabled, don't worry about it for now");
            }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set_speaker_in_scene(string[] parameters){
        string speaker = parameters[0];
        if(string.Equals(npc_name, speaker)){
            other_person.enabled = true;
            other_box.enabled = true;
            romeo.enabled = false;
            romeo_box.enabled = false;
            ui_text.color = rc_color;
        }else{
            romeo.enabled = true;
            romeo_box.enabled = true;
            other_person.enabled = false;
            other_box.enabled = false;
            ui_text.color = romeo_color;
        }
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueSpeaker : MonoBehaviour
{

    public DialogueRunner dialogueRunner;
    public Image romeo;
    public Image other_person;
    public string npc_name = "";
	
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
            romeo.enabled = false;
        }else{
            romeo.enabled = true;
            other_person.enabled = false;
        }
    }
}

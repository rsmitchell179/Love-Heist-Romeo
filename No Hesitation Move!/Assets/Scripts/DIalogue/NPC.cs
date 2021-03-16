using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/// attached to the non-player characters, and stores the name of the Yarn
/// node that should be run when you talk to them.
public class NPC : MonoBehaviour
{

    // public string characterName = "";

    public DialogueRunner diaRun;

    public string talkToNode;

    public string first_node;
    public string second_node;

    public static bool has_spoken;

    [Header("Optional")]
    public YarnProgram scriptToLoad;

    void Awake()
    {
    	try{
            diaRun = FindObjectOfType<DialogueRunner>();
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in SpaceContinue, don't worry about it for now");
            }

        try{
            diaRun.AddCommandHandler("set_has_spoken", set_has_spoken);
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in DialogueSpeaker, don't worry about it for now");
            }
    }

    void Start()
    {
    	// has_spoken = false;

        if (scriptToLoad != null)
        {
            // Yarn.Unity.DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            diaRun.Add(scriptToLoad);
        }
    }

    void Update()
    {
    	if(has_spoken != true){
    		Debug.Log("talkToNode = first_node");
    		talkToNode = first_node;
    	}else{
    		Debug.Log("talkToNode = second_node");
    		talkToNode = second_node;
    	}
    }

    // [YarnCommand("set_has_spoken")]
    public void set_has_spoken(string[] parameters){
    	Debug.Log("set_has_spoken");
        has_spoken = bool.Parse(parameters[0]);
    }
}
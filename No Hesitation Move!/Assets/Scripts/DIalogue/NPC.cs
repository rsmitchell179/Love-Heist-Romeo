using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/// attached to the non-player characters, and stores the name of the Yarn
/// node that should be run when you talk to them.
public class NPC : MonoBehaviour
{
    public DialogueRunner diaRun;

    public string talkToNode;

    public string first_node;
    public string second_node;

    public int bool_index;

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
    	if(GlobalVars.bool_array[bool_index] != true){
    		// Debug.Log("talkToNode = first_node");
    		talkToNode = first_node;
    	}else{
    		// Debug.Log("talkToNode = second_node");
    		talkToNode = second_node;
    	}
    }

    public void set_has_spoken(string[] parameters){

    	if(bool_index == 0 || bool_index % 2 == 0)
    	{
    		GlobalVars.bool_array[0] = bool.Parse(parameters[0]);
    		GlobalVars.bool_array[2] = bool.Parse(parameters[0]);
    		GlobalVars.bool_array[4] = bool.Parse(parameters[0]);
    	}
    	else
    	{
    		GlobalVars.bool_array[1] = bool.Parse(parameters[0]);
    		GlobalVars.bool_array[3] = bool.Parse(parameters[0]);
    		GlobalVars.bool_array[5] = bool.Parse(parameters[0]);
    	}
        
        // GlobalVars.print_array();
    }
}
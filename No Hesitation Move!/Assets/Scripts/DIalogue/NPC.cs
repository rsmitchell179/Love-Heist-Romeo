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
    public string third_node;

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
        if (scriptToLoad != null)
        {
            diaRun.Add(scriptToLoad);
        }
    }

    void Update()
    {
    	if(GlobalVars.recur_array[bool_index] == 0){
    		talkToNode = first_node;
    	}else if(GlobalVars.recur_array[bool_index] == 1){
    		talkToNode = second_node;
    	}else if(GlobalVars.recur_array[bool_index] == 2){
            talkToNode = third_node;
        }
    }

    public void set_has_spoken(string[] parameters){
        
        if(GlobalVars.recur_array[bool_index] == 0)
        {
            if(bool_index == 0 || bool_index % 2 == 0)
            {
                GlobalVars.recur_array[0] = Int32.Parse(parameters[0]);
                GlobalVars.recur_array[2] = Int32.Parse(parameters[0]);
                GlobalVars.recur_array[4] = Int32.Parse(parameters[0]);
            }
            else
            {
                GlobalVars.recur_array[1] = Int32.Parse(parameters[0]);
                GlobalVars.recur_array[3] = Int32.Parse(parameters[0]);
                GlobalVars.recur_array[5] = Int32.Parse(parameters[0]);
            }
        }
        else
        {
            GlobalVars.recur_array[bool_index] = Int32.Parse(parameters[0]);
        }
    }
}
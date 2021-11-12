using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpaceContinue : MonoBehaviour
{
	// [SerializeField] private TMPro.TMP_Text dialogue = null;
	private TMPro.TMP_Text[] options;
	private int optionSize;
    private DialogueRunner diaRun = null;
	private DialogueUI dialogueUI = null;
	private bool isOptionDisplayed;

    // Start is called before the first frame update
    void Start()
    {
    	isOptionDisplayed = false;
        dialogueUI = FindObjectOfType<DialogueUI>();
        try{
            diaRun = FindObjectOfType<DialogueRunner>();
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in SpaceContinue, don't worry about it for now");
            }
    }

    // Update is called once per frame
    void Update()
    {
        dialoguePick();
    }

    private void SkipDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueUI.MarkLineComplete();
        }

        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     dialogueUI.DialogueComplete();
        //     diaRun.Stop();


        // }
    }

    private void dialoguePick()
    {
    	if(isOptionDisplayed){
    		SelectOption();
    	}
    	else
    	{
    		SkipDialogue();
    	}
    }

    public void SelectOption()
    {
    	if(Input.GetKeyDown(KeyCode.Z)){
    		dialogueUI.SelectOption(0);
    	}

    	if(Input.GetKeyDown(KeyCode.X)){
    		dialogueUI.SelectOption(1);
    	}
    }

    public void SetOptionDisplayed(bool flag)
    {
        isOptionDisplayed = flag;
    }
}

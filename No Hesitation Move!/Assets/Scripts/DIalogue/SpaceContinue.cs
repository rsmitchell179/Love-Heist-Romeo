using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpaceContinue : MonoBehaviour
{
	// [SerializeField] private TMPro.TMP_Text dialogue = null;
	private TMPro.TMP_Text[] options;
	private int optionSize;

	private DialogueUI dialogueUI = null;
	private bool isOptionDisplayed;

    // Start is called before the first frame update
    void Start()
    {
    	isOptionDisplayed = false;
    	// optionSize = dialogueUI.optionButtons.Count;
        dialogueUI = FindObjectOfType<DialogueUI>();
        // for (int i = 0; i < optionSize; i++)
        // {
        //     options[i] = dialogueUI.optionButtons[i].GetComponentInChildren<TMPro.TMP_Text>();
        // }
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

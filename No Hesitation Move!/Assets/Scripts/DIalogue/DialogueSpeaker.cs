using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{

	
    // Start is called before the first frame update
    void Start()
    {
        // dialogueUI = FindObjectOfType<DialogueUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // SetDialogueOnTalkingCharacter();
    }

    // public void SetDialogueOnTalkingCharacter()
    // {
    //     // GameObject character;
    //     string line, name;

    //     // Get the dialogue line
    //     line = dialogueUI.GetLineText();
    //     // Search for the character who's talking
    //     if (line.Contains(":"))
    //         name = line.Substring(0, line.IndexOf(":"));
    //     else
    //         name = "Player";
    //     // // Search the GameObject of the character in the Scene
    //     // character = GameObject.Find(name);
    //     // // Sets the dialogue position
    //     // SetDialoguePosition(character);
    // }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ArtGalleryMinigameComplete : MonoBehaviour
{

	public GameObject owl;
	public GameObject romeo;

	public DialogueRunner diaRun;
	public YarnProgram scriptToLoad;
	public string talktonode;

	public bool has_spoken;

    // Start is called before the first frame update
    void Start()
    {
    	diaRun = FindObjectOfType<DialogueRunner>();
		talktonode = "Start";
    }

    // Update is called once per frame
    void Update()
    {
    	if(has_spoken == false){
    		start_grifton_dialogue();
    	}
    }

    public void start_grifton_dialogue(){
    	// yield return new WaitForSecondsRealtime(1.0f);
    	if(GlobalVars.rc_hasCollect == true)
    	{
			owl.transform.position = new Vector3 (7.01f, 4.08f, 0.0f);
    		romeo.transform.position = new Vector3 (5.35f, 3.5f, 0.0f);
    		diaRun.Add(scriptToLoad);
    		diaRun.StartDialogue(talktonode);
    		has_spoken = true;
    	}
    	
    	// yield return null;
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class jsorbCollect : MonoBehaviour
{
    public GameObject owl;
    public GameObject romeo;
    public GameObject FOV;
    public YarnProgram scriptToLoad;
    public Animator animatior;

    private string talktonode;
    private DialogueRunner diaRun = null;
    public Patrol patrol_script;
    public bool has_spoken;
    // Start is called before the first frame update
    void Start()
    {
        GlobalVars.hasCollect =false;
        try{
            diaRun = FindObjectOfType<DialogueRunner>();
            }catch(NullReferenceException){
                Debug.Log("got nullexceptionerror in SpaceContinue, don't worry about it for now");
            }

        talktonode = "Start";
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.hasCollect ==false){
            check_js_orb();  
        }else{
        	patrol_script.enabled = false;
        	FOV.SetActive(false);
        }
    }

    public void check_js_orb(){
        
    	if(GlobalVars.hasJSorb == true){
            if (GlobalVars.hasCollect == false){
	            GlobalVars.hasCollect =true;
	        	// Debug.Log("yes, it's true, all of it");
	            owl.GetComponent<Patrol>().enabled = false;
	            FOV.SetActive(false);
	            animatior.SetTrigger("FadeOut");

	            if(has_spoken == false){
	            	Debug.Log(has_spoken);
	            	StartCoroutine(fade_in());
	            }
            }
        }
    }

    IEnumerator fade_in(){
        yield return new WaitForSecondsRealtime(1);
        animatior.SetTrigger("FadeIn");
        Debug.Log("start grifton function");
        owl.transform.position = new Vector3(18.5f, 6f, 0f);
        romeo.transform.position = new Vector3(16.5f, 5f, 0f);
        diaRun.Add(scriptToLoad);
        diaRun.StartDialogue(talktonode);
    }
    
    // public void OnFadeComplete(){
    //     if(GlobalVars.hasCollect == true) { 
    //         // Debug.Log("before animation");
    //         animatior.SetTrigger("FadeIn");
    //         // Debug.Log("after animation");           
    //         // owl.GetComponent<Patrol>().enabled = false;
    //         // owl.transform.position = new Vector3(18.5f, 6f, 0f);
    //         // romeo.transform.position = new Vector3(16.5f, 5f, 0f);

    //         // diaRun.Add(scriptToLoad);
    //         // diaRun.StartDialogue(talktonode);
    //         // StartDialogue();}
    //         start_grifton();
    //     }
    // }

    public void start_grifton(){
        Debug.Log("start grifton function");
        owl.transform.position = new Vector3(18.5f, 6f, 0f);
        romeo.transform.position = new Vector3(16.5f, 5f, 0f);

        diaRun.Add(scriptToLoad);
        diaRun.StartDialogue(talktonode);
    }
}

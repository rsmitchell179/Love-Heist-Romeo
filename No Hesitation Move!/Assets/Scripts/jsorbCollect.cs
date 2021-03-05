using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jsorbCollect : MonoBehaviour
{
    public GameObject owl;
    public GameObject romeo;
    private bool hasCollect;
    // Start is called before the first frame update
    void Start()
    {
        hasCollect =false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollect ==false){
            check_js_orb();  
        }   
    }

    public void check_js_orb(){
        
    	if(playerMovement.hasJSorb == true){
            hasCollect =true;
        	// Debug.Log("yes, it's true, all of it");
            owl.GetComponent<Patrol>().enabled = false;
            owl.transform.position = new Vector3(18.5f, 6f, 0f);
            romeo.transform.position = new Vector3(16.5f, 5f, 0f);
        }
    }

    // public void grifton_dialogue(){
    //     if(hasCollect == true){
            
    //     }
    // }
}

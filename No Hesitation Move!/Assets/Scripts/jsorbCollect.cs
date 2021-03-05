using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jsorbCollect : MonoBehaviour
{

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
        	Debug.Log("yes, it's true, all of it");
        }
    }
}

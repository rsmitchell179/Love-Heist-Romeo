using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsorbCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check_js_orb();
    }

    public void check_js_orb(){
    	if(playerMovement.hasJSorb == true){
        	Debug.Log("yes, it's true, all of it");
        }
    }
}

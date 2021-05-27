using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCOrbCaseScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.rc_hasCollect == true)
        {
        	this.gameObject.SetActive(false);
        }
    }
}

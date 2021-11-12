using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTOrbCaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.ft_hasCollect == true)
        {
        	this.gameObject.SetActive(false);
        }

        // if(Input.GetKeyDown(KeyCode.O))
        // {
        //     this.gameObject.SetActive(false);
        // }
    }
}

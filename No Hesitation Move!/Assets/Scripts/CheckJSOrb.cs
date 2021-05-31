using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJSOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.hasJSorb == true)
         {
            this.gameObject.SetActive(false);
         }
    }
}

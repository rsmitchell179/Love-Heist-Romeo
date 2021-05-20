using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardDoor : MonoBehaviour {
	public Collider2D animCollider;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if((GlobalVars.hasJSorb && GlobalVars.hasFTorb && GlobalVars.hasRCorb))
        {
            animCollider.enabled = true;
        }
        else
        {
            animCollider.enabled = false;
        }
    }
}

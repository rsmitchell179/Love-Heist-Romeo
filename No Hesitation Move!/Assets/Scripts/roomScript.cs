using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomScript : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // if we need to relocate the player (from taking a door)
        if (globals.putPlayer)
        {
            player = GameObject.FindWithTag("Player");
            player.transform.position = globals.destPos;
            globals.putPlayer = false;
        }   
    }

    IEnumerator loadScene()
    {
    	yield return new WaitForSeconds(1);
    }

}

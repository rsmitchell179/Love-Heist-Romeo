using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroDoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    // public string destinationScene;
    // public Vector2 destinationCoords;

	public BoxCollider2D outro_collider;

	void Awake()
	{
		outro_collider = GetComponent<BoxCollider2D>();
	}

    void Update()
    {
        if((GlobalVars.hasJSorb && GlobalVars.hasFTorb && GlobalVars.hasRCorb))
        {
            outro_collider.enabled = true;
        }
        else
        {
            outro_collider.enabled = false;
        }

        // if(Input.GetKeyDown(KeyCode.I))
        // {
        //     GlobalVars.hasFTorb = true;
        // }

        // if(Input.GetKeyDown(KeyCode.O))
        // {
        //     GlobalVars.hasJSorb = true;
        // }

        // if(Input.GetKeyDown(KeyCode.P))
        // {
        //     GlobalVars.hasRCorb = true;
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            globals.putPlayer = true;
            // globals.destPos = destinationCoords;
            SceneManager.LoadScene("OutroCutscene");

        }
    }
}

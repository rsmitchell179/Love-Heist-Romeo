using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroDoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    // public string destinationScene;
    // public Vector2 destinationCoords;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            globals.putPlayer = true;
            // globals.destPos = destinationCoords;
            SceneManager.LoadScene("OutroSlideShow");

        }
    }
}

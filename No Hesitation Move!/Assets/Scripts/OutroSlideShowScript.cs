using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroSlideShowScript : MonoBehaviour
{
    // what room we move to after slideshow
    public string nextRoom;

    // sprites for intro frames
    public Sprite[] frame;

    // object's sprite renderer
    SpriteRenderer spr;

    // what frame are we on?
    private int spriteOn = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get the sprite object, so we can change the frame
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        // if we still have frames to go, move to next frame
        if (spriteOn < frame.Length-1)
        {
            spriteOn++;
            spr.sprite = frame[spriteOn];
        // otherwise, go to next room
        } else
        {
            SceneManager.LoadScene(nextRoom);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(nextRoom);
        }
    }
}

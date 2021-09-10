using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RCJukeboxBubble : MonoBehaviour
{

    public Image bubble;
    public Image img_jukebox;
    public GameObject jukebox;
    public bool inside_collider;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        bubble.enabled = false;
        img_jukebox.enabled = false;
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inside_collider == true)
        {
            bubble.enabled = true;
            img_jukebox.enabled = true;
            set_pos(bubble);
        }
        else
        {
            bubble.enabled = false;
            img_jukebox.enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inside_collider = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inside_collider = false;
        }
    }

    void set_pos(Image bub)
    {
        float y_offset = jukebox.GetComponent<SpriteRenderer>().bounds.max.y + 0.4f;
        Vector3 bub_position = new Vector3(jukebox.transform.position.x, y_offset, jukebox.transform.position.z);
        bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }
}

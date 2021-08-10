using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RomeoSpacePress : MonoBehaviour
{

    public Image bubble;
    public Image bubble_child;
    public GameObject romeo;
    public Camera cam;

    bool inside_collider;
    bool has_pressed_space;

    public GameObject Spin;

    // Start is called before the first frame update
    void Start()
    {
        bubble.enabled = false;
        bubble_child.enabled = false;
        cam = FindObjectOfType<Camera>();
        romeo = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    // void Update()
    // {
        // if(inside_collider == true)
        // {
        //     bubble.enabled = true;
        //     bubble_child.enabled = true;
        //     set_pos(bubble);
        //     set_pos(bubble_child);
        // }
        // else
        // {
        //     bubble.enabled = false;
        //     bubble_child.enabled = false;
        // }

        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     has_pressed_space = true;
        // }

        // if(has_pressed_space == true)
        // {
        //     bubble.enabled = false;
        //     bubble_child.enabled = false;
        // }
    // }

     void LateUpdate()
     {
        if(inside_collider == true && GlobalVars.ft_hasCollect == false)
        {
            bubble.enabled = true;
            bubble_child.enabled = true;
            set_pos(bubble);
            set_pos(bubble_child);
        }
        else
        {
            bubble.enabled = false;
            bubble_child.enabled = false;
        }

        if(has_pressed_space == true)
        {
            bubble.enabled = false;
            bubble_child.enabled = false;
        }

        if(Spin.activeSelf == true)
        {
            inside_collider = false;
            has_pressed_space = true;
        }
     }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && has_pressed_space != true)
        {
            inside_collider = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            inside_collider = false;
            has_pressed_space = false;
        }
    }

    void set_pos(Image bub)
    {
        float y_offset = romeo.GetComponent<SpriteRenderer>().bounds.max.y + 0.4f;
        Vector3 bub_position = new Vector3(romeo.transform.position.x, y_offset, romeo.transform.position.z);
        bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }
}

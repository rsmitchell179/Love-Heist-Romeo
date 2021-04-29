using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorScript : MonoBehaviour
{

	public string behind_layer = "Environment_Behind";
	public string above_layer = "Environment_Above";

	public GameObject player;

	public Color new_color;

    // Start is called before the first frame update
    void Start()
    {
    	new_color = this.GetComponent<SpriteRenderer>().color;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > player.transform.position.y)
        {
        	this.GetComponent<SpriteRenderer>().sortingLayerName = behind_layer;
        }
        else
        {
        	this.GetComponent<SpriteRenderer>().sortingLayerName = above_layer;
        }

        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        if(dist < 0.8f && (this.GetComponent<SpriteRenderer>().sortingLayerName == above_layer))
        {
        	new_color.a = 0.5f;
        	this.GetComponent<SpriteRenderer>().color = new_color;
        }
        else
        {
        	new_color.a = 1.0f;
        	this.GetComponent<SpriteRenderer>().color = new_color;
        }
    }
}

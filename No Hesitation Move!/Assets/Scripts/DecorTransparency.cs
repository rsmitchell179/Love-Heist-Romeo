using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorTransparency : MonoBehaviour
{

	[Header("Player")]
	public GameObject player;

	[Header("Object's Opacity")]
	public Color new_color;

	// public Vector3 player_pos;
	[Header("GameObject Offset")]
	public float y_offset;
	public float x_offset;

	[Header("Object's Layer")]
	public DecorScript decor_script;

    // Start is called before the first frame update
    void Start()
    {
        new_color = this.GetComponent<SpriteRenderer>().color;
        player = GameObject.FindWithTag("Player");
        decor_script = this.GetComponent<DecorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // float dist = Vector3.Distance(player.transform.position, this.transform.position);
        float dist_y = player.transform.position.y;
        float dist_x = player.transform.position.x;
        // player_pos = player.transform.position;

        if( this.GetComponent<SpriteRenderer>().bounds.min.y < dist_y - y_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.max.y > dist_y + y_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.min.x < dist_x - x_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.max.x > dist_x + x_offset &&
			this.GetComponent<SpriteRenderer>().sortingLayerName == decor_script.above_layer)
        // (
        // 	(
        // 		(player_pos.y < this.GetComponent<SpriteRenderer>().bounds.max.y) &&
        // 		(player_pos.x < this.GetComponent<SpriteRenderer>().bounds.max.x) &&
        // 		(player_pos.y > this.GetComponent<SpriteRenderer>().bounds.min.y) &&
        // 		(player_pos.x > this.GetComponent<SpriteRenderer>().bounds.min.x)
        // 	)
        // 	&& (this.GetComponent<SpriteRenderer>().sortingLayerName == above_layer)
        // )
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

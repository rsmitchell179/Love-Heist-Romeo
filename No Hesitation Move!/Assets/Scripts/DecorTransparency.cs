using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorTransparency : MonoBehaviour
{

	[Header("Player")]
	public GameObject player;

	[Header("Object Color")]
	public Color new_color;

	// public Vector3 player_pos;
	[Header("Object Offset")]
	public float y_offset;
	public float x_offset;

	[Header("Transparency Levels")]
	public float transparent;
	private float opaque = 1.0f;
	private float fade_speed = 3.0f;
	public bool is_behind;

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

        if(
        	this.GetComponent<SpriteRenderer>().bounds.min.y < dist_y - y_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.max.y > dist_y + y_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.min.x < dist_x - x_offset &&
        	this.GetComponent<SpriteRenderer>().bounds.max.x > dist_x + x_offset &&
			this.GetComponent<SpriteRenderer>().sortingLayerName == decor_script.above_layer)
			
        {
        	// new_color.a = Mathf.Lerp(opaque, transparent, Time.time);
        	// this.GetComponent<SpriteRenderer>().color = new_color;
        	// if(this.GetComponent<SpriteRenderer>().sortingLayerName == decor_script.above_layer){
        		is_behind = true;
        	// }
        }
        else
        {
        	is_behind = false;
        	new_color.a = opaque;
        	this.GetComponent<SpriteRenderer>().color = new_color;
        	// StartCoroutine(grad_fade2());
        }

        if(is_behind == true)
        {
        	StartCoroutine(grad_fade(opaque, transparent));
        }
    }

    IEnumerator grad_fade(float first_state, float sec_state)
    {

    	float f_state = first_state;
    	float s_state = sec_state;

    	for(float t = 0.0f; t < 1.0f; t += Time.deltaTime * fade_speed)
    	{
    		new_color.a = Mathf.Lerp(f_state, s_state, t);
    		this.GetComponent<SpriteRenderer>().color = new_color;
    		yield return null;
    	}
    }
}

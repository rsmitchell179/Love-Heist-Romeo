using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlecardScript : MonoBehaviour
{

	private float first_fade = 0.3f;
	private float second_fade = 0.3f;
	private float wait_time = 2.5f;
	public bool is_fading;
	private Image this_image;
	private Color this_alpha;
	public playerMovement p_move;
    public int card_index;

	void Awake()
	{
		
		this_image = this.GetComponent<Image>();
		p_move = FindObjectOfType<playerMovement>();
        StartCoroutine(titlecard_anim());
	}

    // Start is called before the first frame update
    void Start()
    {
    	this_image.CrossFadeAlpha(0, 0.0f, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(is_fading == true && GlobalVars.has_seen_card[card_index] == false)
        {
        	this_image.CrossFadeAlpha(1, first_fade, false);

            p_move.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            p_move.moveSpeed = 0.0f;
            p_move.anim.SetFloat("Speed", 0.0f);
            p_move.movement.x = 0;
            p_move.movement.y = 0;
            
        }

        if(is_fading == false)
        {
            p_move.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        	this_image.CrossFadeAlpha(0, second_fade, false);
            GlobalVars.has_seen_card[card_index] = true;
        	StartCoroutine(start_walk());

            p_move.moveSpeed = p_move.move_normal;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            is_fading = false;
        }
    }

    IEnumerator titlecard_anim()
    {

    	is_fading = true;

    	yield return new WaitForSecondsRealtime(wait_time);

    	is_fading = false;
    	
    }

    IEnumerator start_walk()
    {
    	yield return new WaitForSecondsRealtime(1.0f);

    	// while(p_move.move_normal <= 3.14f)
    	// {
    	// 	p_move.move_normal += 0.1f;
    	// 	yield return null;
    	// }
    }
}

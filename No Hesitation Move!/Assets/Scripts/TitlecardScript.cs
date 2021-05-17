using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlecardScript : MonoBehaviour
{

	private float first_fade = 0.6f;
	private float second_fade = 0.3f;
	private float wait_time = 3.0f;
	public bool is_fading;
	private Image this_image;
	private Color this_alpha;

	void Awake()
	{
		this_image = this.GetComponent<Image>();
		// this_alpha = this_image.color;
		// this_alpha.a = 0f;
		// this_image.color = this_alpha;
	}

    // Start is called before the first frame update
    void Start()
    {
    	this_image.CrossFadeAlpha(0, 0.0f, true);
        StartCoroutine(titlecard_anim());
    }

    // Update is called once per frame
    void Update()
    {
        if(is_fading == true)
        {
        	// this_image.enabled = true;
        	this_image.CrossFadeAlpha(1, first_fade, false);
        }

        if(is_fading == false)
        {
        	this_image.CrossFadeAlpha(0, second_fade, false);
        	// this_image.enabled = false;

        }
    }

    IEnumerator titlecard_anim()
    {
    	is_fading = true;

    	yield return new WaitForSecondsRealtime(wait_time);

    	is_fading = false;
    }
}

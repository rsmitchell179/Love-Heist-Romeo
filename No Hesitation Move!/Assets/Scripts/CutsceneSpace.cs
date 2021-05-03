using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneSpace : MonoBehaviour
{

	private float wait_time = 4f;

	public Image space_press;

	public bool is_pressed = false;

    // Start is called before the first frame update
    void Start()
    {
    	space_press.enabled = false;
    	start_space();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        	set_is_pressed();
        	StopAllCoroutines();
        	space_press.enabled = false;
        }

        if(is_pressed == true)
        {
        	space_press.enabled = false;
        	wait_time = 60f;
        }
    }

    void set_is_pressed()
    {
    	if(is_pressed == false)
    	{
    		is_pressed = true;
    	}
    }

    void start_space()
    {
    	StartCoroutine(wait_five());
    }

    IEnumerator wait_five()
    {
    	yield return new WaitForSecondsRealtime(wait_time);
    	space_press.enabled = true;
    }
}

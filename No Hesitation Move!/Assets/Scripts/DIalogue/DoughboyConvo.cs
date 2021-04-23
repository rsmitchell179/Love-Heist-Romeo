using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoughboyConvo : MonoBehaviour
{

	public Image bubble_1;
	public Image bubble_2;
	public Image bubble_3;

	public TMP_Text ui_text_1;
	public TMP_Text ui_text_2;
	public TMP_Text ui_text_3;

	private float char_delay = 0.1f;
	private float time_delay = 0.5f;

	public string actual_text_1;
	public string actual_text_2;
	public string actual_text_3;

	public GameObject db_1;
	public GameObject db_2;
	public GameObject db_3;

	public string current_text = "";

	public Camera cam;

	public bool first_done = false;
	public bool second_done = false;

    // Start is called before the first frame update
    void Start()
    {
        bubble_1.enabled = false;
        bubble_2.enabled = false;
        bubble_3.enabled = false;

        ui_text_1.enabled = false;
        ui_text_2.enabled = false;
        ui_text_3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		start_convo();
    	}
    }

    public void start_convo()
    {
    	// bubble_1.enabled = true;
    	// set_pos(bubble_1, db_1);
    	// StartCoroutine(first_db(actual_text_1, ui_text_1));
    	// StartCoroutine(set_first_done());

    	// if(first_done == true)
    	// {
    	// 	bubble_2.enabled = true;
    	// 	set_pos(bubble_2, db_2);
    	// 	StartCoroutine(second_db(actual_text_2, ui_text_2));
    	// 	// StartCoroutine(set_second_done());
    	// }

    	// if(second_done == true)
    	// {
    	// 	bubble_3.enabled = true;
    	// 	set_pos(bubble_3, db_3);
    	// 	StartCoroutine(third_db(actual_text_3, ui_text_3));
    	// }

    	StartCoroutine(db_convo());

    }

    IEnumerator db_convo()
    {
    	for(int i = 0; i <= actual_text_1.Length; i++)
    	{
    		ui_text_1.enabled = true;
    		bubble_1.enabled = true;
    		current_text = actual_text_1.Substring(0, i);
    		ui_text_1.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

    	for(int i = 0; i <= actual_text_2.Length; i++)
    	{
    		ui_text_2.enabled = true;
    		bubble_2.enabled = true;
    		current_text = actual_text_2.Substring(0, i);
    		ui_text_2.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

    	for(int i = 0; i <= actual_text_3.Length; i++)
    	{
    		ui_text_3.enabled = true;
    		bubble_3.enabled = true;
    		current_text = actual_text_3.Substring(0, i);
    		ui_text_3.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}
    }

    // IEnumerator first_db(string actual_text, TMP_Text ui_text)
    // {
    // 	for(int i = 0; i <= actual_text.Length; i++)
    // 	{
    // 		ui_text.enabled = true;
    // 		current_text = actual_text.Substring(0, i);
    // 		ui_text.text = current_text;
    // 		StartCoroutine(set_first_done());
    // 		yield return new WaitForSecondsRealtime(char_delay);
    // 	}
    // }

    // IEnumerator second_db(string actual_text, TMP_Text ui_text)
    // {
    // 	for(int i = 0; i <= actual_text.Length; i++)
    // 	{
    // 		ui_text.enabled = true;
    // 		current_text = actual_text.Substring(0, i);
    // 		ui_text.text = current_text;
    // 		StartCoroutine(set_second_done());
    // 		yield return new WaitForSecondsRealtime(char_delay);
    // 	}
    // }

    // IEnumerator third_db(string actual_text, TMP_Text ui_text)
    // {
    // 	for(int i = 0; i <= actual_text.Length; i++)
    // 	{
    // 		ui_text.enabled = true;
    // 		current_text = actual_text.Substring(0, i);
    // 		ui_text.text = current_text;
    // 		yield return new WaitForSecondsRealtime(char_delay);
    // 	}
    // }

    // IEnumerator set_first_done()
    // {
    // 	first_done = true;
    // 	yield return new WaitForSecondsRealtime(time_delay);
    // }

    // IEnumerator set_second_done()
    // {
    // 	second_done = true;
    // 	yield return new WaitForSecondsRealtime(time_delay);
    // }

    void OnTriggerExit2D(Collider2D other)
    {	
    	if(other.tag == "Player"){
    		StopAllCoroutines();
    		current_text = "";
    		StartCoroutine(delay_setfalse());
    	// bubble.enabled = false;
    	}
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player"){
    		set_pos(bubble_1, db_1);
    		set_pos(bubble_2, db_2);
    		set_pos(bubble_3, db_3);
    	}
    }

    IEnumerator delay_setfalse()
    {
    	yield return new WaitForSeconds (0.0f);
    	bubble_1.enabled = false;
        bubble_2.enabled = false;
        bubble_3.enabled = false;

        ui_text_1.enabled = false;
        ui_text_2.enabled = false;
        ui_text_3.enabled = false;

        first_done = false;
        second_done = false;
    }

    void set_pos(Image bubble, GameObject db)
    {
    	float y_offset = db.GetComponent<SpriteRenderer>().bounds.max.y + 0.5f;
    	Vector3 bub_position = new Vector3(db.transform.position.x, y_offset, db.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }

    IEnumerator wait_seconds()
    {
    	yield return new WaitForSecondsRealtime(time_delay);
    }
}

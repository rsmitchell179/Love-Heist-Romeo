using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoughboyConvoTrio : MonoBehaviour
{

	[Header("Bubbles")]
	public Image bubble_1;
	public Image bubble_2;
	public Image bubble_3;

	[Header("UI Text")]
	public TMP_Text ui_text_1;
	public TMP_Text ui_text_2;
	public TMP_Text ui_text_3;

	[Header("Delay Times")]
	private float char_delay = 0.05f;
	private float time_delay = 0.3f;

	[Header("Doughboy Dialogue")]
	public string actual_text_1;
	public string actual_text_2;
	public string actual_text_3;

	[Header("Doughboys")]
	public GameObject db_1;
	public GameObject db_2;
	public GameObject db_3;

	[Header("Display Text")]
	public string current_text = "";

	[Header("Camera")]
	public Camera cam;

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
    	StartCoroutine(db_convo());
    }

    IEnumerator db_convo()
    {
    	for(int i = 0; i <= actual_text_1.Length; i++)
    	{
    		set_pos(bubble_1, db_1);
    		bubble_1.enabled = true;
    		ui_text_1.enabled = true;
    		current_text = actual_text_1.Substring(0, i);
    		ui_text_1.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

    	for(int i = 0; i <= actual_text_2.Length; i++)
    	{
    		set_pos(bubble_2, db_2);
    		bubble_2.enabled = true;
    		ui_text_2.enabled = true;
    		current_text = actual_text_2.Substring(0, i);
    		ui_text_2.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

    	for(int i = 0; i <= actual_text_3.Length; i++)
    	{
    		set_pos(bubble_3, db_3);
    		bubble_3.enabled = true;
    		ui_text_3.enabled = true;
    		current_text = actual_text_3.Substring(0, i);
    		ui_text_3.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}
    }

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
    	// yield return new WaitForSecondsRealtime(0.5f);
    	// set_pos(bubble_1, db_1);
    	bubble_1.enabled = false;
    	ui_text_1.enabled = false;
    	// yield return new WaitForSecondsRealtime(0.2f);
    	// set_pos(bubble_2, db_2);
        bubble_2.enabled = false;
        ui_text_2.enabled = false;
        // yield return new WaitForSecondsRealtime(0.2f);
        // set_pos(bubble_3, db_3);
        bubble_3.enabled = false;
        ui_text_3.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
    }

    void set_pos(Image bubble, GameObject db)
    {
    	float y_offset = db.GetComponent<SpriteRenderer>().bounds.max.y + 0.4f;
    	Vector3 bub_position = new Vector3(db.transform.position.x, y_offset, db.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }

    IEnumerator wait_seconds()
    {
    	yield return new WaitForSecondsRealtime(time_delay);
    }
}

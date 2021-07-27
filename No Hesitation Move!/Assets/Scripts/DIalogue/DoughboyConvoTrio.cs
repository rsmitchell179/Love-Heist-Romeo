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
	private float char_delay = 0.03f;
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

    [Header("Bubble Enabled")]
    public bool exit_area;

    [Header("Doughboy Class Script Reference")]
    public DoughboyClass db_class_1;
    public DoughboyClass db_class_2;
    public DoughboyClass db_class_3;

    void Awake()
    {
        db_class_1 = db_1.gameObject.GetComponent<DoughboyClass>();
        db_class_2 = db_2.gameObject.GetComponent<DoughboyClass>();
        db_class_3 = db_3.gameObject.GetComponent<DoughboyClass>();

        ui_text_1 = bubble_1.GetComponentInChildren<TMP_Text>();
        ui_text_2 = bubble_2.GetComponentInChildren<TMP_Text>();
        ui_text_3 = bubble_3.GetComponentInChildren<TMP_Text>();

        actual_text_1 = db_class_1.doughboy_text;
        actual_text_2 = db_class_2.doughboy_text;
        actual_text_3 = db_class_3.doughboy_text;
    }

    // Start is called before the first frame update
    void Start()
    {
        bubble_1.enabled = false;
        bubble_2.enabled = false;
        bubble_3.enabled = false;

        ui_text_1.enabled = false;
        ui_text_2.enabled = false;
        ui_text_3.enabled = false;

        bubble_1.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_1.CrossFadeAlpha(0.0f, 0.0f, false);
        bubble_2.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_2.CrossFadeAlpha(0.0f, 0.0f, false);
        bubble_3.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_3.CrossFadeAlpha(0.0f, 0.0f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(exit_area == true)
        {
            set_pos(bubble_1, db_1, db_class_1.offset);
            set_pos(bubble_2, db_2, db_class_2.offset);
            set_pos(bubble_3, db_3, db_class_3.offset);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bubble_1.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_1.CrossFadeAlpha(0.0f, 0.0f, false);
        bubble_2.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_2.CrossFadeAlpha(0.0f, 0.0f, false);
        bubble_3.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text_3.CrossFadeAlpha(0.0f, 0.0f, false);

    	StartCoroutine(start_text());
    }

    IEnumerator start_text()
    {
        bubble_1.CrossFadeAlpha(1.0f, 0.1f, false);
        ui_text_1.CrossFadeAlpha(1.0f, 0.1f, false);

    	for(int i = 0; i <= actual_text_1.Length; i++)
    	{
    		set_pos(bubble_1, db_1, db_class_1.offset);
    		ui_text_1.enabled = true;
    		current_text = actual_text_1.Substring(0, i);
    		ui_text_1.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

        bubble_2.CrossFadeAlpha(1.0f, 0.1f, false);
        ui_text_2.CrossFadeAlpha(1.0f, 0.1f, false);

    	for(int i = 0; i <= actual_text_2.Length; i++)
    	{
    		set_pos(bubble_2, db_2, db_class_2.offset);
    		ui_text_2.enabled = true;
    		current_text = actual_text_2.Substring(0, i);
    		ui_text_2.text = current_text;
    		yield return new WaitForSecondsRealtime(char_delay);
    	}

    	yield return new WaitForSecondsRealtime(time_delay);

        bubble_3.CrossFadeAlpha(1.0f, 0.1f, false);
        ui_text_3.CrossFadeAlpha(1.0f, 0.1f, false);

    	for(int i = 0; i <= actual_text_3.Length; i++)
    	{
    		set_pos(bubble_3, db_3, db_class_3.offset);
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
            StartCoroutine(end_text());
            exit_area = true;
    	}
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player"){

            bubble_1.enabled = true;
            bubble_2.enabled = true;
            bubble_3.enabled = true;

            set_pos(bubble_1, db_1, db_class_1.offset);
            set_pos(bubble_2, db_2, db_class_2.offset);
            set_pos(bubble_3, db_3, db_class_3.offset);
    	}
    }

    IEnumerator end_text()
    {
    	bubble_1.CrossFadeAlpha(0.0f, 0.1f, false);
        ui_text_1.CrossFadeAlpha(0.0f, 0.1f, false);
        yield return new WaitForSecondsRealtime(0.1f);

        bubble_2.CrossFadeAlpha(0.0f, 0.1f, false);
        ui_text_2.CrossFadeAlpha(0.0f, 0.1f, false);
        yield return new WaitForSecondsRealtime(0.1f);

        bubble_3.CrossFadeAlpha(0.0f, 0.1f, false);
        ui_text_3.CrossFadeAlpha(0.0f, 0.1f, false);
        yield return new WaitForSecondsRealtime(0.1f);

        bubble_1.enabled = false;
        ui_text_1.enabled = false;
        bubble_2.enabled = false;
        ui_text_2.enabled = false;
        bubble_3.enabled = false;
        ui_text_3.enabled = false;
        exit_area = false;

        yield return new WaitForSecondsRealtime(0.0f);
    }

    void set_pos(Image bubble, GameObject db, float offset)
    {
    	float y_offset = db.GetComponent<SpriteRenderer>().bounds.max.y + offset;
    	Vector3 bub_position = new Vector3(db.transform.position.x, y_offset, db.transform.position.z);
    	bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }

    IEnumerator wait_seconds()
    {
    	yield return new WaitForSecondsRealtime(time_delay);
    }
}

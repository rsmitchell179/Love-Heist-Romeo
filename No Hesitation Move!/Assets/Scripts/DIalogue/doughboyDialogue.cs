using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class DoughboyDialogue : MonoBehaviour
{

    [Header("UI Components")]
    public Image bubble;
    public TMP_Text ui_text;

    [Header("This Character")]
    public GameObject character;

    [Header("Camera")]
    public Camera cam;

    [Header("Char Delay")]
    private float delay = 0.03f;

    [Header("Dialogue Text")]
    public string curr_text;
    private string current_text = "";

    [Header("Bubble Enabled")]
    public bool render_dialogue;

    public DoughboyClass db_class;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        ui_text = bubble.GetComponentInChildren<TMP_Text>();
        db_class = this.gameObject.GetComponent<DoughboyClass>();
        bubble.enabled = false;
        ui_text.enabled = false;
        curr_text = db_class.doughboy_text;
        bubble.CrossFadeAlpha(0.0f, 0.0f, false);
        ui_text.CrossFadeAlpha(0.0f, 0.0f, false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            bubble.CrossFadeAlpha(0.0f, 0.0f, false);
            ui_text.CrossFadeAlpha(0.0f, 0.0f, false);
        }
    }

    void Update()
    {
        if(render_dialogue == true)
        {
            set_pos(bubble);
        }
    }

    IEnumerator start_text()
    {
        bubble.enabled = true;
        bubble.CrossFadeAlpha(1.0f, 0.1f, false);
        ui_text.CrossFadeAlpha(1.0f, 0.1f, false);

        yield return new WaitForSecondsRealtime(0.1f);

        for(int i = 0; i <= curr_text.Length; i++)
        {   
            ui_text.enabled = true;
            current_text = curr_text.Substring(0, i);
            ui_text.text = current_text;
            yield return new WaitForSecondsRealtime(delay);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && render_dialogue == false){
            render_dialogue = true;
            StartCoroutine(start_text());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {   
        if(other.tag == "Player"){
            StopAllCoroutines();
            current_text = "";

            StartCoroutine(end_text());
        }
    }

    IEnumerator end_text()
    {

        // yield return new WaitForSecondsRealtime(0.5f);

        bubble.CrossFadeAlpha(0.0f, 0.1f, false);
        ui_text.CrossFadeAlpha(0.0f, 0.1f, false);
        yield return new WaitForSecondsRealtime(0.1f);

        ui_text.enabled = false;
        bubble.enabled = false;

        yield return new WaitForSeconds (0.2f);

        render_dialogue = false;


    }

    void set_pos(Image bub)
    {
        float y_offset = character.GetComponent<SpriteRenderer>().bounds.max.y + db_class.offset;
        Vector3 bub_position = new Vector3(character.transform.position.x, y_offset, character.transform.position.z);
        bubble.transform.position = cam.WorldToScreenPoint(bub_position);
    }
}

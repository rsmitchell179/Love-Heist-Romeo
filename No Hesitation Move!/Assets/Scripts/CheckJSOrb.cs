using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CheckJSOrb : MonoBehaviour
{
    [Header("Animator")]
    public Animator js_orb;

    [Header("Player Components")]
    public playerMovement p_move;
    public GameObject romeo;

    [Header("UI Components")]
    public Image img_fade;
    public GameObject ui_js_orb;
    public Camera cam;

    [Header("Owl Components")]
    public GameObject owl;
    public GameObject FOV;
    public Patrol patrol_script;

    [Header("Yarnspinner Components")]
    public YarnProgram scriptToLoad;
    private string talktonode;
    private DialogueRunner dia_run;
   
    

    // Start is called before the first frame update
    void Start()
    {
        romeo = GameObject.FindWithTag("Player");
        p_move = romeo.GetComponent<playerMovement>();
        img_fade.CrossFadeAlpha(0, 0.0f, true);
        dia_run = FindObjectOfType<DialogueRunner>();
        talktonode = "Start";
        patrol_script = owl.GetComponent<Patrol>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(GlobalVars.hasJSorb == true)
    //     {
    //         this.gameObject.SetActive(false);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(get_js_orb());
        }
    }

    IEnumerator get_js_orb()
    {
        p_move.anim.SetFloat("Speed", 0.0f);
        patrol_script.enabled = false;
        FOV.SetActive(false);
        p_move.enabled = false;
        js_orb.Play("js_orb_anim", 0, 0f);

        yield return new WaitForSecondsRealtime(3.5f);

        js_orb.enabled = false;
        Vector3 orb_coords = cam.ScreenToWorldPoint(ui_js_orb.transform.position);
        orb_coords.z = 1.0f;

        float time = 0f;
        float duration = 1.5f;
        Vector3 start_position = this.transform.position;

        while(time < duration)
        {
            this.transform.position = Vector3.Lerp(start_position, orb_coords, time / duration);
            time += Time.deltaTime;
            Debug.Log(time);
            yield return null;
        }

        GlobalVars.hasJSorb = true;

        // this.transform.position = orb_coords;

        yield return new WaitForSecondsRealtime(0.5f);

        img_fade.CrossFadeAlpha(1, 0.5f, false);

        yield return new WaitForSecondsRealtime(1.0f);

        js_orb.enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        owl.transform.position = new Vector3(25.5f, 9.2f, 0f);
        romeo.transform.position = new Vector3(23.66f, 8.92f, 0f);
        p_move.anim.SetFloat("Horizontal", 1.0f);

        yield return new WaitForSecondsRealtime(2.5f);

        img_fade.CrossFadeAlpha(0, 0.5f, false);

        yield return new WaitForSecondsRealtime(0.5f);

        dia_run.Add(scriptToLoad);
        dia_run.StartDialogue(talktonode);
        p_move.enabled = true;
        this.gameObject.SetActive(false);
    }
}

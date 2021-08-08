using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CheckJSOrb : MonoBehaviour
{
    public Animator js_orb;
    public playerMovement p_move;
    public Image img_fade;
    public GameObject owl;
    public GameObject romeo;
    public GameObject FOV;
    public YarnProgram scriptToLoad;
    private string talktonode;
    private DialogueRunner dia_run;
    public Patrol patrol_script;

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
    void Update()
    {
        if(GlobalVars.hasJSorb == true)
        {
            this.gameObject.SetActive(false);
        }
    }

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

        yield return new WaitForSecondsRealtime(2.3f);

        img_fade.CrossFadeAlpha(1, 0.5f, false);

        yield return new WaitForSecondsRealtime(1.0f);

        js_orb.enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        owl.transform.position = new Vector3(25.5f, 9.2f, 0f);
        romeo.transform.position = new Vector3(23.66f, 8.92f, 0f);

        yield return new WaitForSecondsRealtime(0.5f);

        p_move.anim.SetFloat("Horizontal", 1.0f);
        img_fade.CrossFadeAlpha(0, 0.5f, false);

        yield return new WaitForSecondsRealtime(0.5f);

        dia_run.Add(scriptToLoad);
        dia_run.StartDialogue(talktonode);
        GlobalVars.hasJSorb = true;
        p_move.enabled = true;
    }
}

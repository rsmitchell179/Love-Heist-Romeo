using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRCOrb : MonoBehaviour
{

    public Animator rc_orb;
    public playerMovement p_move;
    public float duration_time;
    public Image img_fade;

    void Awake()
    {
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
        duration_time = rc_orb.GetCurrentAnimatorStateInfo(0).length;
        img_fade.CrossFadeAlpha(0, 0.0f, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.hasRCorb == true)
        {
        	this.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(get_rc_orb());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(get_rc_orb());
        }
    }

    IEnumerator get_rc_orb()
    {

        p_move.anim.SetFloat("Speed", 0.0f);
        p_move.enabled = false;
        rc_orb.Play("rc_orb_anim", 0, 0f);

        yield return new WaitForSecondsRealtime(3.5f);

        img_fade.CrossFadeAlpha(1, 0.5f, false);

        yield return new WaitForSecondsRealtime(3.5f);

        img_fade.CrossFadeAlpha(0, 0.5f, false);

        GlobalVars.hasRCorb = true;
        p_move.enabled = true;

    }
}

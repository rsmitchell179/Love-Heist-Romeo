using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFTOrb : MonoBehaviour
{

    [Header("Animator")]
    public Animator ft_orb;

    [Header("Player Components")]
    public playerMovement p_move;

    [Header("UI Components")]
    public Image img_fade;
    public GameObject ui_ft_orb;
    public Camera cam;

    void Awake()
    {
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
        img_fade.CrossFadeAlpha(0, 0.0f, true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(get_ft_orb());
        }
    }

    void Update()
    {
        if(GlobalVars.hasFTorb == true && GlobalVars.ft_orb_get == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator get_ft_orb()
    {
        p_move.anim.SetFloat("Speed", 0.0f);
        p_move.enabled = false;
        ft_orb.Play("ft_orb_anim", 0, 0f);

        yield return new WaitForSecondsRealtime(3.5f);

        ft_orb.enabled = false;
        Vector3 orb_coords = cam.ScreenToWorldPoint(ui_ft_orb.transform.position);
        orb_coords.z = 1.0f;

        float time = 0f;
        float duration = 1.5f;
        Vector3 start_position = this.transform.position;

        while(time < duration)
        {
            this.transform.position = Vector3.Lerp(start_position, orb_coords, time / duration);
            time += Time.deltaTime;
            // Debug.Log(time);
            yield return null;
        }

        this.GetComponent<SpriteRenderer>().enabled = false;
        GlobalVars.hasFTorb = true;

        // yield return new WaitForSecondsRealtime(0.5f);

        // img_fade.CrossFadeAlpha(1, 0.5f, false);

        // yield return new WaitForSecondsRealtime(3.5f);

        // img_fade.CrossFadeAlpha(0, 0.5f, false);

        p_move.enabled = true;
        GlobalVars.ft_orb_get = true;
    }
}

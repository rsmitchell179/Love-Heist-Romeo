using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSPlank : MonoBehaviour
{
    public GameObject parent_player;
    public Animator parent_player_anim;
    public playerMovement p_move;
    public GameObject plank_location;
    public Camera main_camera;
    public GameObject temp_camera_location;
    public GameObject final_camera_location;

    void Awake()
    {
        parent_player_anim = parent_player.GetComponent<Animator>();
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(start_anim());
        }
    }

    IEnumerator start_anim()
    {
        Debug.Log("in start_anim");

        p_move.anim.SetFloat("Speed", 0.0f);
        p_move.enabled = false;

        yield return new WaitForSecondsRealtime(0.1f);

        temp_camera_location.transform.position = main_camera.transform.position;
        main_camera.GetComponent<cameraFollow>().cameraFollows = temp_camera_location.transform;

        float time = 0f;
        float duration = 1.5f;
        Vector3 first_camera_location = temp_camera_location.transform.position;

        while(time < duration)
        {   
            main_camera.orthographicSize += (1f/380f);
            temp_camera_location.gameObject.transform.position = Vector3.Lerp(first_camera_location, final_camera_location.transform.position, time / duration);
            time += Time.deltaTime;
            // Debug.Log(time);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.25f);

        p_move.anim.Play("playerWalkRight");

        Vector3 start_position = p_move.gameObject.transform.position;
        time = 0f;

        while(time < duration)
        {
            p_move.gameObject.transform.position = Vector3.Lerp(start_position, plank_location.transform.position, time / duration);
            time += Time.deltaTime;
            // Debug.Log(time);
            yield return null;
        }

        p_move.anim.Play("Idle", 0, 0.0f);

        yield return new WaitForSecondsRealtime(0.5f);

        p_move.anim.Play("playerFall", 0, 0.0f);
        parent_player_anim.Play("js_jump_animation", 0, 0f);
    }
}

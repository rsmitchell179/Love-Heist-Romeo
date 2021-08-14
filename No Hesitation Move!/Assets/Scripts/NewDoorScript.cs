using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDoorScript : MonoBehaviour
{
    public int which_door;
    public int which_scene;

    public float wait_time = 0.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(leave_scene());
        }
    }

    IEnumerator leave_scene()
    {
        GlobalVars.which_door = which_door;
        SceneManager.LoadScene(which_scene);

        yield return null;
    }
}

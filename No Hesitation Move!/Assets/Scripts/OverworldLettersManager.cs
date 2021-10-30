using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldLettersManager : MonoBehaviour
{

    public Animator[] letter_objects;
    [SerializeField]
    private int count;
    private float wait_time;

    void Awake()
    {
        count = letter_objects.Length;

        for(int i = 1; i < count; i++)
        {
            // delay_object(i);
            if(GlobalVars.chap_array[i] == true)
            {
                StartCoroutine(delay_object(i));
                wait_time += 0.5f;
            }
            else
            {
                continue;
            }
            
            // Debug.Log(i);
        }
    }

    void Update()
    {
        // FOR DEV PURPOSES
        if(Input.GetKeyDown(KeyCode.O))
        {
            for(int i = 1; i < GlobalVars.chap_array.Length; i++)
            {
                GlobalVars.chap_array[i] = true;
            }
        }
    }

    // void delay_object(int curr_letter)
    // {
    //     // Debug.Log("current letter is " + curr_letter);
    //     float time = 0f;
    //     float duration = Random.Range(0.1f, 2.1f);

    //     Debug.Log("current letter is " + curr_letter + " and its duration is " + duration);

    //     while(time < duration)
    //     {
    //         time += Time.deltaTime;
    //     }

    //     if(GlobalVars.chap_array[curr_letter] == true)
    //     {
    //         letter_objects[curr_letter].SetActive(true);
    //     }
    // }

    IEnumerator delay_object(int curr_letter)
    {

        Debug.Log("current letter is " + curr_letter + " and its duration is " + wait_time);

        yield return new WaitForSecondsRealtime(wait_time);

        // if(GlobalVars.chap_array[curr_letter] == true)
        // {
        letter_objects[curr_letter].enabled = true;
        // }
    }
}

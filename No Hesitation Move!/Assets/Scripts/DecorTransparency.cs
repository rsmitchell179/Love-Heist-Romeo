using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorTransparency : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Parent Object")]
    public SpriteRenderer parent_obj;

    [Header("Transparency Levels")]
    public Color transparent;
    public Color opaque;
    public float transparency_level;
    private float fade_speed = 0.5f;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        parent_obj = this.transform.parent.GetComponent<SpriteRenderer>();
        opaque = parent_obj.color;
        transparent = new Color(opaque.r, opaque.g, opaque.b, transparency_level);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(gradual_fade(parent_obj.color, transparent));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(gradual_fade(parent_obj.color, opaque));
        }
    }

    IEnumerator gradual_fade(Color start_state, Color end_state)
    {
        float time = 0;
        while(time < fade_speed)
        {
            time += Time.deltaTime;
            parent_obj.color = Color.Lerp(start_state, end_state, time/fade_speed);
            yield return null;
        }
    }
}

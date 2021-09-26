using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RCJukeboxText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform text_transform;
    public RectTransform end_transform;
    public RectTransform reset_transform;
    public float speed;

    public RCJukebox jukebox_script;
    public string[] track_titles;
    public int track_title_index;

    void Awake()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        text_transform = text.GetComponent<RectTransform>();
    }

    void Update()
    {
        text_transform.anchoredPosition = Vector2.MoveTowards(text_transform.anchoredPosition, end_transform.anchoredPosition, speed * Time.deltaTime);

        if(text_transform.anchoredPosition == end_transform.anchoredPosition)
        {
            Vector2 reset_pos = new Vector2(reset_transform.anchoredPosition.x + 550, reset_transform.anchoredPosition.y);
            text_transform.anchoredPosition = reset_pos;
        }

        track_title_index = jukebox_script.current_step;

        text.text = track_titles[track_title_index];

        if(track_title_index == 1)
        {
            text.fontSize = 25;
        }
        else
        {
            text.fontSize = 36;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzlePiece : MonoBehaviour
{
    public bool is_not_finished;
    public bool activated;
    private SpriteRenderer puzzle_piece;
    // Start is called before the first frame update
    void Start()
    {
        is_not_finished = true;
        puzzle_piece = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && is_not_finished == true)
        {
            transform.localScale = Vector3.one * 1.2f;
            activated = true;
            puzzle_piece.sortingOrder = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")  && is_not_finished == true)
        {
            transform.localScale = Vector3.one;
            activated = false;
            puzzle_piece.sortingOrder = 2;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(is_not_finished == false)
        {
            transform.localScale = Vector3.one;
            activated = false;
        }
    }
}

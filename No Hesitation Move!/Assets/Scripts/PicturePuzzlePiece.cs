using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzlePiece : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            transform.localScale = Vector3.one * 1.2f;
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            transform.localScale = Vector3.one;
            activated = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorScriptTop : MonoBehaviour
{
    [Header("Sorting Layers")]
    public string behind_layer = "Environment_Behind";
    public string above_layer = "Environment_Above";
    public GameObject parent_layer;

    [Header("Player")]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(parent_layer.GetComponent<DecorScript>().enabled == false)
        {
            if(this.transform.position.y > player.transform.position.y)
            {
                this.GetComponent<SpriteRenderer>().sortingLayerName = behind_layer;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sortingLayerName = above_layer;
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingLayerName = above_layer;
        }
    }
}

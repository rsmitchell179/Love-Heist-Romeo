using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject doughboy_canvas;
    public GameObject dialogue_canvas;

    private int interval = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % interval == 0)
        {
            if(dialogue_canvas.activeInHierarchy == true)
            {
                doughboy_canvas.SetActive(false);
            }
            else
            {
                doughboy_canvas.SetActive(true);
            }
        }
    }
}

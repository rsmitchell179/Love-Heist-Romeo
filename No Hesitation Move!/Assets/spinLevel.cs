using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinLevel : MonoBehaviour
{

    public GameObject levelup;
    public GameObject leveldown;
    public float startWaitTime;
    private float waitTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            leveldown.SetActive(true);
            levelup.SetActive(false);
            waitTime = startWaitTime;
            }
        if (Input.GetKeyDown(KeyCode.S)){
            leveldown.SetActive(true);
            levelup.SetActive(false);
            waitTime = startWaitTime;
            }
        if (waitTime <=0) {
            levelup.SetActive(true);
            leveldown.SetActive(false);
        }
        waitTime -= Time.deltaTime;
        
        
    }
}

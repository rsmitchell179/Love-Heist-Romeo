using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGalleryMinigameComplete : MonoBehaviour
{

	public GameObject owl;
	public GameObject romeo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.rc_hasCollect == true){
        	StartCoroutine(start_grifton_dialogue());
        	
        }
    }

    public IEnumerator start_grifton_dialogue(){
    	yield return new WaitForSecondsRealtime(1.0f);
    	owl.transform.position = new Vector3 (7.01f, 4.08f, 0.0f);
    	romeo.transform.position = new Vector3 (5.35f, 3.5f, 0.0f);
    }
}

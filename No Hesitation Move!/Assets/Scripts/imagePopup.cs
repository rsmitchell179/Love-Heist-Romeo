using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class imagePopup : MonoBehaviour
{

	public Image letter;
	public DialogueRunner dialogueRunner;

	public void Awake() {

        // Create a new command called 'custom_wait', which waits for one second.
        dialogueRunner.AddCommandHandler(
            "img_showup",
            img_showup
        );
    }

	void Start()
	{
		letter.enabled = false;
		Debug.Log("here");
	}

	void Update()
	{

	}

	public void img_showup(string[] param, System.Action onComplete)
	{
		Debug.Log("before letter enabled");
		letter.enabled = true;
		Debug.Log("after letter enabled");

		StartCoroutine(close_pop(onComplete));
		// if(Input.GetKey(KeyCode.Tab)){
		// 	Debug.Log("keycode Tab");
		// 	letter.enabled = false;
		// 	onComplete();
		// }
	}

	public IEnumerator close_pop(System.Action onComplete){
		// yield return null;
		while(true){
			if(Input.GetKey(KeyCode.Tab)){
				Debug.Log("keycode Tab");
				letter.enabled = false;
				onComplete();
				yield break;
			}
			yield return null;
		}
	}
}

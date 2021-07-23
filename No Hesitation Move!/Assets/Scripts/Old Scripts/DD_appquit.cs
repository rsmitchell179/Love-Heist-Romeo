using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_appquit : MonoBehaviour
{

	public GameObject appquit_script;

	void Awake()
	{

	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.appquit_script);
    }
}

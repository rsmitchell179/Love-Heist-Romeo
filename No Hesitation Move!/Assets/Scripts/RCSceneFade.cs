using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RCSceneFade : MonoBehaviour
{
    public Image img_fade;

    void Awake()
    {
        img_fade.CrossFadeAlpha(0, 0.0f, true);

        if(GlobalVars.rc_hasCollect == true && GlobalVars.rc_has_seen_fade == false)
        {
            img_fade.CrossFadeAlpha(1, 0.0f, true);
            StartCoroutine(start_img_fade());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator start_img_fade()
    {
        img_fade.CrossFadeAlpha(0, 1.4f, false);

        yield return null;

        GlobalVars.rc_has_seen_fade = true;
    }
}

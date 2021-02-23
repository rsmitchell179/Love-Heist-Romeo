using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{
    // i've been told not to use globals, but i also grew up coding in BASIC so old habits die hard lmfao
    public static bool putPlayer = false;
    public static Vector2 destPos;
    // don't kill it!!
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}



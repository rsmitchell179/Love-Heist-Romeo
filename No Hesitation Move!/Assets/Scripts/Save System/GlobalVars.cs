using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	// kameron bless up

	// IMPORTANT: RECUR CHAR. LIST ORDER
	//-----------------------------------
    // [0] rc_budalia
    // [1] rc_vinny
    // [2] ft_budalia
    // [3] ft_vinny
    // [4] js_budalia
    // [5] js_vinny

	// bool to check once if list has been instantiated
	public static bool has_run;

	public static string curr_scene;
	public static int[] recur_array = new int[6];
	public static float[] position = new float[3];
	public static bool hasJSorb;
    public static bool hasFTorb;
    public static bool hasRCorb;
    public static bool js_hasCollect;
    public static bool ft_hasCollect;
    public static bool rc_hasCollect;
    public static bool rc_has_spoken;
    public static bool rc_has_seen_fade;
    public static bool[] has_seen_card = new bool[4];
    public static bool chapISeen;
    public static bool chapIVSeen;
    public static bool chapIXSeen;
    public static bool chapIISeen;
    public static bool chapVIIISeen;
    public static bool chapVSeen;

	// test print, check if array stuff is being added
	
	public static void print_array(){
		// recur_array.Add(false);
		// Debug.Log("here in print_array" + recur_array.Count);
		for(int i = 0; i < 6; i++)
		{
			Debug.Log("array index " + i + " is " + recur_array[i]);
		}
	}
}

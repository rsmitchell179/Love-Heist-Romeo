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

	/* bool to check once if list has been instantiated
	I have no clue if this is still necessary */
	public static bool has_run;

	/* string to get the scene that is currently active */
	public static string curr_scene;

	/* array that holds the recurring characters' current dialogue */
	public static int[] recur_array = new int[6];

	/* array that holds the players' position */
	public static float[] position = new float[3];

	/* bools that activate the orbs in the orbs ui */
	public static bool hasJSorb;
    public static bool hasFTorb;
    public static bool hasRCorb;

    /* some random bools that do something, idk 
    probably used for minigame completion checks */
    public static bool js_hasCollect;
    public static bool ft_hasCollect;
    public static bool rc_hasCollect;

    /* bools used to check if the orb was picked up */
    public static bool js_orb_get;
    public static bool ft_orb_get;
    public static bool rc_orb_get;

    /* rc_has_spoken is used for the dialogue with owl */
    public static bool rc_has_spoken;

    /* rc_has_seen_fade is for the fade out when you
    complete the rc minigame */
    public static bool rc_has_seen_fade;

    /* opens the door from rc art gallery to overworld */
    public static bool rc_open_door;

    /* bool array for seeing the neighborhood cards */

    /* 
    [0] overworld
    [1] fancy town
    [2] jealous sea
    [3] reject city
    */
    public static bool[] has_seen_card = new bool[4];

    /* bools for the chapters, idk */
    public static bool chapISeen;
    public static bool chapIVSeen;
    public static bool chapIXSeen;
    public static bool chapIISeen;
    public static bool chapVIIISeen;
    public static bool chapVSeen;

    /* int for checking which door it is */
    public static int which_door;

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

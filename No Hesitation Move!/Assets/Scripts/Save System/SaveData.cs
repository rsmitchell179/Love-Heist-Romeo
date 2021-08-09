using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int[] recur_array; 
    public string scene;
    public float[] position;
    public bool hasJSorb;
    public bool hasFTorb;
    public bool hasRCorb;
    public bool seenChapI;
    public bool seenChapIV;
    public bool seenChapIX;
    public bool seenChapII;
    public bool seenChapVIII;
    public bool seenChapV;

    public bool js_hasCollect;
    public bool ft_hasCollect;
    public bool rc_hasCollect;
    public bool rc_has_spoken;
    public bool rc_has_seen_fade;
    public bool rc_open_door;
    public bool[] has_seen_card;
    public bool boot_resolution;
    public int curr_resolution;

    public SaveData()
    {
    	recur_array = new int[6];
    	
    	recur_array[0] = GlobalVars.recur_array[0];
    	recur_array[1] = GlobalVars.recur_array[1];
    	recur_array[2] = GlobalVars.recur_array[2];
    	recur_array[3] = GlobalVars.recur_array[3];
    	recur_array[4] = GlobalVars.recur_array[4];
    	recur_array[5] = GlobalVars.recur_array[5];

        scene = GlobalVars.curr_scene;

        position = new float[3];
        position[0] = GlobalVars.position[0];
        position[1] = GlobalVars.position[1];
        position[2] = GlobalVars.position[2];

        hasJSorb = GlobalVars.hasJSorb;
        hasFTorb = GlobalVars.hasFTorb;
        hasRCorb = GlobalVars.hasRCorb;

        js_hasCollect = GlobalVars.js_hasCollect;
        ft_hasCollect = GlobalVars.ft_hasCollect;
        rc_hasCollect = GlobalVars.rc_hasCollect;
        rc_has_spoken = GlobalVars.rc_has_spoken;
        rc_has_seen_fade = GlobalVars.rc_has_seen_fade;
        rc_open_door = GlobalVars.rc_open_door;

        has_seen_card = new bool[4];
        has_seen_card[0] = GlobalVars.has_seen_card[0];
        has_seen_card[1] = GlobalVars.has_seen_card[1];
        has_seen_card[2] = GlobalVars.has_seen_card[2];
        has_seen_card[3] = GlobalVars.has_seen_card[3];

  //   	for(int i = 0; i < 6; i++)
		// {
		// 	Debug.Log("saved array index " + i + " is " + recur_array[i]);
		// }
    }
}

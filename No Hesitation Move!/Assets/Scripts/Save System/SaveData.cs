using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool[] bool_array; 
    public string scene;
    public float[] position;
    public bool hasJSorb;
    public bool hasFTorb;
    public bool hasRCorb;

    public SaveData()
    {
    	bool_array = new bool[6];
    	
    	bool_array[0] = GlobalVars.bool_array[0];
    	bool_array[1] = GlobalVars.bool_array[1];
    	bool_array[2] = GlobalVars.bool_array[2];
    	bool_array[3] = GlobalVars.bool_array[3];
    	bool_array[4] = GlobalVars.bool_array[4];
    	bool_array[5] = GlobalVars.bool_array[5];

        scene = GlobalVars.curr_scene;

        position = new float[3];
        position[0] = GlobalVars.position[0];
        position[1] = GlobalVars.position[1];
        position[2] = GlobalVars.position[2];

        hasJSorb = GlobalVars.hasJSorb;
        hasFTorb = GlobalVars.hasFTorb;
        hasRCorb = GlobalVars.hasRCorb;

  //   	for(int i = 0; i < 6; i++)
		// {
		// 	Debug.Log("saved array index " + i + " is " + bool_array[i]);
		// }
    }
}

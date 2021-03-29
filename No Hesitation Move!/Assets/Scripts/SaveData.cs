using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool[] bool_array; 

    public SaveData()
    {
    	bool_array = new bool[6];
    	
    	bool_array[0] = GlobalVars.bool_array[0];
    	bool_array[1] = GlobalVars.bool_array[1];
    	bool_array[2] = GlobalVars.bool_array[2];
    	bool_array[3] = GlobalVars.bool_array[3];
    	bool_array[4] = GlobalVars.bool_array[4];
    	bool_array[5] = GlobalVars.bool_array[5];

  //   	for(int i = 0; i < 6; i++)
		// {
		// 	Debug.Log("saved array index " + i + " is " + bool_array[i]);
		// }
    }
}

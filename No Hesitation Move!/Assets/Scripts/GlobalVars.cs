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

	// list for keeping bools
	public static List<bool> bool_array;

	// function to add indices into list, once
	// aka the start, but not actually, but also is
	public static void bool_array_start()
	{
		if(has_run != true){
			bool_array = new List<bool>();
			bool_array.Add(false);
			bool_array.Add(false);
			bool_array.Add(false);
			bool_array.Add(false);
			bool_array.Add(false);
			bool_array.Add(false);
			has_run = true;
		}
	}

	// test print, check if array stuff is being added
	/*
	public static void print_array(){
		// bool_array.Add(false);
		Debug.Log("here in print_array" + bool_array.Count);
		foreach(bool obj in bool_array)
		{
			Debug.Log(obj);
		}
	}
	*/
}

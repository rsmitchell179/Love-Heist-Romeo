using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

	public string file_path;
	public string new_game_load;

    // Start is called before the first frame update
    void Start()
    {
        file_path = Application.persistentDataPath + "/player.lhr";
        new_game_load = "IntroCutscene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clear_save()
    {
    	if(File.Exists(file_path))
    	{
    		File.Delete(file_path);
    	}

    	for(int i = 0; i < 6; i++)
    	{
    		GlobalVars.recur_array[i] = 0;
    	}

        GlobalVars.hasJSorb = false;
        GlobalVars.hasFTorb = false;
        GlobalVars.hasRCorb = false;

    }

    public void load_save()
    {
    	if(File.Exists(file_path))
    	{
	        Debug.Log("LOADING DATA...");
	        SaveData new_data = SaveSys.load_data();
	        // GlobalVars.print_array();

	        GlobalVars.recur_array[0] = new_data.recur_array[0];
	        GlobalVars.recur_array[1] = new_data.recur_array[1];
	        GlobalVars.recur_array[2] = new_data.recur_array[2];
	        GlobalVars.recur_array[3] = new_data.recur_array[3];
	        GlobalVars.recur_array[4] = new_data.recur_array[4];
	        GlobalVars.recur_array[5] = new_data.recur_array[5];

            GlobalVars.hasJSorb = new_data.hasJSorb;
            GlobalVars.hasFTorb = new_data.hasFTorb;
            GlobalVars.hasRCorb = new_data.hasRCorb;

	        SceneManager.LoadScene(new_data.scene);

	        // Vector3 load_position = new Vector3(new_data.position[0], new_data.position[1], new_data.position[2]);
	        // transform.position = load_position;

	        // GlobalVars.recur_array.Add(new_data.recur_array[0]);
	        // GlobalVars.recur_array.Add(new_data.recur_array[1]);
	        // GlobalVars.recur_array.Add(new_data.recur_array[2]);
	        // GlobalVars.recur_array.Add(new_data.recur_array[3]);
	        // GlobalVars.recur_array.Add(new_data.recur_array[4]);
	        // GlobalVars.recur_array.Add(new_data.recur_array[5]);
	    }
	    else
	    {
	    	SceneManager.LoadScene(new_game_load);
	    }
    }
}

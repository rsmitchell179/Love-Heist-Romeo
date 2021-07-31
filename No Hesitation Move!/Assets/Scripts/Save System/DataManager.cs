using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

	public string file_path;
	public string new_game_load;
    Vector2 load_pos;

    // Start is called before the first frame update
    void Start()
    {
        file_path = Application.persistentDataPath + "/player.lhr";
        new_game_load = "IntroCutscene";
        load_pos = new Vector2(1.29f, 1.0f);
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

        globals.destPos = load_pos;

        GlobalVars.js_hasCollect = false;
        GlobalVars.ft_hasCollect = false;
        GlobalVars.rc_hasCollect = false;
        GlobalVars.rc_has_spoken = false;
        GlobalVars.chapISeen = false;
    	GlobalVars.chapIVSeen = false;
    	GlobalVars.chapIXSeen = false;
    	GlobalVars.chapIISeen = false;
    	GlobalVars.chapVIIISeen = false;
    	GlobalVars.chapVSeen = false;

        for(int i = 0; i < 4; i++)
        {
        	GlobalVars.has_seen_card[i] = false;
        }

        // PlayerPrefs.DeleteAll();
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
      		// GlobalVars.chapISeen = new_data.chapISeen;
	    	// GlobalVars.chapIVSeen = new_data.chapIVSeen;
	    	// GlobalVars.chapIXSeen = new_data.chapIXSeen;
	    	// GlobalVars.chapIISeen = new_data.chapIISeen;
	    	// GlobalVars.chapVIIISeen = new_data.chapVIIISeen;
	    	// GlobalVars.chapVSeen = new_data.chapVSeen;
            
	        SceneManager.LoadScene(new_data.scene);
	    }
	    else
	    {
            clear_save();
	    	SceneManager.LoadScene(new_game_load);
	    }
    }
}

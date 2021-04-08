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
        new_game_load = "IntroSlideShow";
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
    }

    public void load_save()
    {
    	if(File.Exists(file_path))
    	{
	        Debug.Log("LOADING DATA...");
	        SaveData new_data = SaveSys.load_data();
	        // GlobalVars.print_array();

	        GlobalVars.bool_array[0] = new_data.bool_array[0];
	        GlobalVars.bool_array[1] = new_data.bool_array[1];
	        GlobalVars.bool_array[2] = new_data.bool_array[2];
	        GlobalVars.bool_array[3] = new_data.bool_array[3];
	        GlobalVars.bool_array[4] = new_data.bool_array[4];
	        GlobalVars.bool_array[5] = new_data.bool_array[5];

	        SceneManager.LoadScene(new_data.scene);

	        // Vector3 load_position = new Vector3(new_data.position[0], new_data.position[1], new_data.position[2]);
	        // transform.position = load_position;

	        // GlobalVars.bool_array.Add(new_data.bool_array[0]);
	        // GlobalVars.bool_array.Add(new_data.bool_array[1]);
	        // GlobalVars.bool_array.Add(new_data.bool_array[2]);
	        // GlobalVars.bool_array.Add(new_data.bool_array[3]);
	        // GlobalVars.bool_array.Add(new_data.bool_array[4]);
	        // GlobalVars.bool_array.Add(new_data.bool_array[5]);
	    }
	    else
	    {
	    	SceneManager.LoadScene(new_game_load);
	    }
    }
}

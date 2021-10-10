using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RCArtGalleryMusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((get_scene_index() == 13) || (get_scene_index() == 19))
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    int get_scene_index()
    {
        int curr_scene_index = SceneManager.GetActiveScene().buildIndex;

        return curr_scene_index;
    }

}

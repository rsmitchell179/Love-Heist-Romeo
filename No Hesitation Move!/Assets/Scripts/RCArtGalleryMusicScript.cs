using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RCArtGalleryMusicScript : MonoBehaviour
{
    static RCArtGalleryMusicScript instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
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
            instance = null;
            Destroy(this.gameObject);
        }
    }

    int get_scene_index()
    {
        int curr_scene_index = SceneManager.GetActiveScene().buildIndex;

        return curr_scene_index;
    }

}

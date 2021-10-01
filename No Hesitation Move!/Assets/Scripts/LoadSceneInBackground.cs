using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneInBackground : MonoBehaviour
{
    public int scene_index;

    void Awake()
    {
        Application.backgroundLoadingPriority = ThreadPriority.High;
        StartCoroutine(load_scene_async(scene_index));
    }

    IEnumerator load_scene_async(int index)
    {

        yield return new WaitForSeconds(0.1f);

        AsyncOperation async_load = SceneManager.LoadSceneAsync(index);
        async_load.allowSceneActivation = false;

        while(!async_load.isDone)
        {
            Debug.Log("Loading progress: " + (async_load.progress * 100) + "%");
            yield return null;
        }
    }
}
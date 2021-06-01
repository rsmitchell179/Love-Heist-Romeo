using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSlotsOnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject SlotsButton;

    [SerializeField]
    string levelToLoad;

    playerMovement p_movement;

    void Awake()
    {
        p_movement = FindObjectOfType<playerMovement>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SlotsButton.SetActive(false);
            p_movement.enabled = true;
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
        {
            SlotsButton.SetActive(true);
            p_movement.enabled = false;
        }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SlotsButton.SetActive(false);
        }
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

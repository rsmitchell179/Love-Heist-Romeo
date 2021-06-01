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

    bool is_colliding;

    void Awake()
    {
        p_movement = FindObjectOfType<playerMovement>();
    }

    void Update()
    {

    }

    void LateUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SlotsButton.SetActive(false);
            p_movement.enabled = true;
            // is_colliding = false;
        }

        if(is_colliding == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SlotsButton.SetActive(true);
                p_movement.enabled = false;
            }
        }
    }

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            is_colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SlotsButton.SetActive(false);
            is_colliding = false;
        }
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

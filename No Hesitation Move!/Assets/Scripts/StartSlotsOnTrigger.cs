using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSlotsOnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject SlotsButton;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SlotsButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SlotsButton.SetActive(false);
        }
    }

    public void OpenSlotsGame()
    {
        SceneManager.LoadScene("Slots");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour
{

    [SerializeField]
    RacketAI racketAI;

    [SerializeField]
    SpriteRenderer BallSprite;

    [SerializeField]
    Sprite[] ballSprites;

    [SerializeField]
    Text playerScoreTxt, AIScoreTxt;

    [SerializeField]
    float subtractor, speedIncrease;

    int playerScore, AIScore;


    [SerializeField]
    GameObject winPanel;


    public bool gameOver;

    public static PongManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScoreTxt.text = "Player: " + playerScore;
        AIScoreTxt.text = "Enemy: " + AIScore;
    }

    public void AIScored()
    {
        AIScore++;
        AIScoreTxt.text = "Enemy: " + AIScore;
    }

    public void PlayerScored()
    {
        playerScore++;
        playerScoreTxt.text = "Player: " + playerScore;
        if (playerScore >= 3)
        {
            winPanel.SetActive(true);
            gameOver = true;
        }
        else
        {

            float enemySize = racketAI.transform.localScale.y - subtractor;
            if (racketAI.transform.localScale.y >= 0.8f)
                racketAI.transform.localScale = new Vector3(racketAI.transform.localScale.x, enemySize, racketAI.transform.localScale.z);
            //if (racketAI.speed <= 45)
                racketAI.speed += speedIncrease;
        }
    }

    public void ChangeBallSprite()
    {
        BallSprite.sprite = ballSprites[Random.Range(0, ballSprites.Length)];
    }
    public void Back()
    {
        SceneManager.LoadScene("FT Mansion Room");
    }

    public void Restart()
    {

        SceneManager.LoadScene("Pong");
    }
}

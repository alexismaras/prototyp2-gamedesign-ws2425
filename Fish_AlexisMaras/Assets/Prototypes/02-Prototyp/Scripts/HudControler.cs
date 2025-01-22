using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudControler : MonoBehaviour
{
    float screenWidth;
    float screenHeight;
    [SerializeField] SceneSwitcher sceneSwitcher;
    [SerializeField] GameObject scoreBar;
    [SerializeField] GameObject scoreIndicator;
    [SerializeField] GameObject booksScoreboard;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pickupManager;

    [SerializeField] Sprite booksScoreboard_1;
    [SerializeField] Sprite booksScoreboard_2;
    [SerializeField] Sprite booksScoreboard_3;

    public int score = 0;
    public int booksCollected = 0;


    [SerializeField] float scoreBarHeight;
    [SerializeField] float scoreBarWidth;
    [SerializeField] int scoreMax;
    [SerializeField] int scoreMin;
    // Start is called before the first frame update
    void Start()
    {
        GetScreenSize();
        scoreBar.transform.position = new Vector3((screenWidth * 0.5f * (-1)) + (scoreBarWidth), (-4.3f), 0);
        scoreIndicator.transform.position = new Vector3((screenWidth * 0.5f * (-1)) + (scoreBarWidth), (-4.3f), 0);
        booksScoreboard.transform.position = new Vector3((screenWidth * 0.5f) - (scoreBarWidth * 1.5f), (-4.3f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        GameScoreManagement();
        GetScreenSize();
        scoreBar.transform.position = new Vector3(screenWidth * 0.5f * (-1) + (scoreBarWidth), (-4.3f), 0);
        scoreIndicator.transform.position = new Vector3(screenWidth * 0.5f * (-1) + (scoreBarWidth) + ((scoreBarWidth/((scoreMin * (-1))+scoreMax)) * score), (-4.3f), 0);
        booksScoreboard.transform.position = new Vector3((screenWidth * 0.5f) - (scoreBarWidth * 1.5f), (-4.3f), 0);
    }

    void GetScreenSize()
    {
        screenWidth = Screen.width * 0.02f;
        screenHeight = Screen.height * 0.02f;
    }

    void GameScoreManagement()
    {
        if (score <= scoreMin || score >= scoreMax)
        {
            EndGame();
        }
    }
    public void ChangeBookScoreboard()
    {
        if (booksCollected == 1)
        {
            booksScoreboard.GetComponent<SpriteRenderer>().sprite = booksScoreboard_1;
        }
        else if (booksCollected == 2)
        {
            booksScoreboard.GetComponent<SpriteRenderer>().sprite = booksScoreboard_2;
        }
        else if (booksCollected == 3)
        {
            booksScoreboard.GetComponent<SpriteRenderer>().sprite = booksScoreboard_3;
            EndGame();
        }
    }

    void EndGame()
    {
        sceneSwitcher.ChangeScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneControll : MonoBehaviour
{

    public static PlaneControll instance;
    public GameObject PausePanel;
    public GameObject GameOverText;
    public GameObject GameEndText;
    public GameObject ResumeText;
    public Text scoreText;
    public Text highScoreText;
    public bool GameOver = false;
    public bool GameEnd = false;
    public bool GamePaused = false;

    public float scrollSpeed = -1.5f;

    int score = 0;
    int planeHighScore = 0;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
        
    }

    void Start()
    {
        planeHighScore = PlayerPrefs.GetInt("planeHighScore");

        highScoreText.text = "High score " + planeHighScore.ToString();
    }

    // When called, resume the game time
    public void Resume()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        // If game has ended, freeze the game
        if (GameEnd == true)
        {
            Time.timeScale = 0;
        }

        // What to do when the player hits escape or the back button on their phone
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = true;
            Time.timeScale = 0;

            PausePanel.SetActive(true);
            ResumeText.SetActive(true);
        }

        // Update the highscore if the current score is higher than the previous highscore
        if (score > planeHighScore)
        {
            planeHighScore = score;
            PlayerPrefs.SetInt("planeHighScore", planeHighScore);
            PlayerPrefs.Save();


            highScoreText.text = "High score " + planeHighScore.ToString();
        }
    }

    // Add one point to the score when passing cloud successfully, if game is over return to 0
    public void PlaneScored()
    {
        if (GameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score " + score.ToString();
    }

    // Set game to be over if plane dies
    public void PlaneDied()
    {
        PausePanel.SetActive(true);
        GameOverText.SetActive(true);
        GameOver = true;
    }

    // End game when plane reaches the end of the map
    public void PlaneEnd()
    {
        PausePanel.SetActive(true);
        GameEndText.SetActive(true);
        GameEnd = true;
    }
}

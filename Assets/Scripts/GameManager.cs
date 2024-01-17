using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;


    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighscoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;

    private void Awake() {

        // initialize ads in your game with gameID, you will find it in unity dashboard online
        // also you can get banned if you click ok your ads for testing just add your device in unity dashboard, enter your phone name and name id
        //Advertisement.Initialize("");

        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);

        GetHighscore();

    }

    // private means that it cannot be called from another class
    private void GetHighscore() {
        // Player preferences it stores and accesses it between game sessions
        // great to store integers, floats and string
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }


    public void IncreaseScore(int points) {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore) {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score.ToString();
        }

    }

    public void OnBombHit() {

        // great place to advertize
        //Advertisement.Show();

        // is stops the game, normal stime is 1
        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        // neveikia nes natnaujina
        gameOverPanelHighscoreText.text = "Highscore: " + highscore.ToString();
        gameOverPanel.SetActive(true);

        //Debug.Log("Bomb hit");    
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        //dont need to to it anymore
        //gameOverPanelScoreText.text = "Score: 0";

        //Checkes for the tags of objects and then destroys them
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }

    public void PlayRandomSliceSound() {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}

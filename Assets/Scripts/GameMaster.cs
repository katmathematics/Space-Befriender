using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip game_music;
    public GameOverDisplay gameOverScreen;

    public TMP_Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelWin() {

    }

    public void LevelLose(int score = 0) {
        Time.timeScale = 0;
        gameOverScreen.Setup(score);
    }

    public void displayScore(int score = 0) {
        pointsText.text = "Score: " + score.ToString();
    }
}

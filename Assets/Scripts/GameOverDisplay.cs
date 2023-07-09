using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public TMP_Text finalPointsText;
    public GameObject mainUI;
    public GameObject pauseUI;
    public GameObject pauseButton;

    void Start() {
        gameObject.SetActive(false);
    }

    public void Setup(int score = 0) {
        finalPointsText.text = "Final Score: " + score.ToString();
        mainUI.SetActive(false);
        pauseUI.SetActive(false);
        pauseButton.SetActive(false);
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        ReloadGame();
        //Invoke("ReloadGame",.03f);
    }

    public void ExitButton() {

    }

    public void ReloadGame() {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}

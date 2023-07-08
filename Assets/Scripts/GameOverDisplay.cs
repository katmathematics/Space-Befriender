using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDisplay : MonoBehaviour
{
    public Text pointsText;

    void Start() {
        gameObject.SetActive(false);
    }

    public void Setup(int score = 0) {
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

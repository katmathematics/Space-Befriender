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

    private bool isGamePaused = false;

    public PauseDisplay pauseUI;

    public int score = 0;

    public GameObject simpleTank;
    public GameObject speedyTank;
    public GameObject sillyTank;

    private List<GameObject> simpleBattalion =  new List<GameObject>();
    private List<GameObject> speedyBattalion = new List<GameObject>();
    private List<GameObject> sillyBattalion = new List<GameObject>();

    private int picker = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        LevelController();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePauseGame();
        }
    }

    public void LevelController() {
        //Simple,Speedy,Silly,Simple+Simple,Simple+Speedy,Simple+Silly,Speedy+Speedy,Speedy+Silly
        if (score == 0) {
            simpleBattalion.Add(Instantiate(simpleTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 1) {
            Destroy(simpleBattalion[0], 0f);
            simpleBattalion.RemoveAt(0);
            speedyBattalion.Add(Instantiate(speedyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 2) {
            Destroy(speedyBattalion[0], 0f);
            speedyBattalion.RemoveAt(0);
            sillyBattalion.Add(Instantiate(sillyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 3) {
            Destroy(sillyBattalion[0], 0f);
            sillyBattalion.RemoveAt(0);
            simpleBattalion.Add(Instantiate(simpleTank, new Vector3(-1, -3.5f, -9), Quaternion.identity));
            simpleBattalion.Add(Instantiate(simpleTank, new Vector3(1, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 4) {
            Destroy(simpleBattalion[0], 0f);
            simpleBattalion.RemoveAt(0);
            speedyBattalion.Add(Instantiate(speedyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 5) {
            Destroy(speedyBattalion[0], 0f);
            speedyBattalion.RemoveAt(0);
            sillyBattalion.Add(Instantiate(sillyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 6) {
            Destroy(simpleBattalion[0], 0f);
            simpleBattalion.RemoveAt(0);
            Destroy(sillyBattalion[0], 0f);
            sillyBattalion.RemoveAt(0);
            speedyBattalion.Add(Instantiate(speedyTank, new Vector3(-1, -3.5f, -9), Quaternion.identity));
            speedyBattalion.Add(Instantiate(speedyTank, new Vector3(1, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 7) {
            Destroy(speedyBattalion[0], 0f);
            speedyBattalion.RemoveAt(0);
            sillyBattalion.Add(Instantiate(sillyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else if (score == 8) {
            Destroy(speedyBattalion[0], 0f);
            speedyBattalion.RemoveAt(0);
            sillyBattalion.Add(Instantiate(sillyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
        }
        else {
            picker = Random.Range(0, 3);
            if (picker == 0) {
                simpleBattalion.Add(Instantiate(simpleTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
            }
            else if (picker == 1) {
                speedyBattalion.Add(Instantiate(speedyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
            }
            else {
                sillyBattalion.Add(Instantiate(sillyTank, new Vector3(0, -3.5f, -9), Quaternion.identity));
            }
        }
    }

    public void LevelLose() {
        Time.timeScale = 0;
        gameOverScreen.Setup(score);
    }

    public void displayScore() {
        pointsText.text = "Score: " + score.ToString();
    }

    public void togglePauseGame() {
        if (isGamePaused) {
            Time.timeScale = 1;
            audioSource.Play();
            isGamePaused = false;
            pauseUI.togglePauseMenu(isGamePaused);
        }
        else {
            Time.timeScale = 0;
            audioSource.Pause();
            isGamePaused = true;
            pauseUI.togglePauseMenu(isGamePaused);
        }
    }

    public void incrementScore() {
        score = score + 1;
        displayScore();
    }
}
